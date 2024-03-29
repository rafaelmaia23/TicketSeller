﻿using AutoMapper;
using FluentResults;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Dtos.MovieSessionDto;
using TicketSeller.Models.Dtos.SeatDto;
using TicketSeller.Models.Models;
using TicketSeller.Services.Services.IServices;
namespace TicketSeller.Services.Services;

public class MovieSessionService : IMovieSessionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MovieSessionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Result<ReadMovieSessionDto> AddMovieSessions(CreateMovieSessionDto createMovieSessionDto)
    {
        Movie movie = _unitOfWork.Movie.GetById(x => x.Id == createMovieSessionDto.MovieId);
        if (movie == null) return Result.Fail("Movie not found");
        Cinema cinema = _unitOfWork.Cinema.GetById(x => x.Id == createMovieSessionDto.CinemaId);
        if (cinema == null) return Result.Fail("Cinema not found");
        MovieSession movieSession = _mapper.Map<MovieSession>(createMovieSessionDto);
        CalculateEndTime(movieSession);
        if (CheckIfRoomIsAvailable(movieSession))
        {
            _unitOfWork.MovieSession.Add(movieSession);
            _unitOfWork.Save();
            for (char row = 'A'; row <= 'O'; row++)
            {
                for (int column = 1; column <= 10; column++)
                {
                    movieSession.Seats.Add(new Seat(row, column, true, movieSession.Id));
                }
            }
            _unitOfWork.Save();
            ReadMovieSessionDto readMovieSessionDto = _mapper.Map<ReadMovieSessionDto>(movieSession);
            return Result.Ok(readMovieSessionDto);
        }
        return null;
    }

    public IEnumerable<ReadMovieSessionDto> GetMovieSessions(int skip, int take)
    {
        IEnumerable<MovieSession> movieSessions = _unitOfWork.MovieSession.GetAll().Skip(skip).Take(take);
        IEnumerable<ReadMovieSessionDto> readMovieSessionDtos = _mapper.Map<List<ReadMovieSessionDto>>(movieSessions);
        return readMovieSessionDtos;
    }

    public ReadMovieSessionDto GetMovieSessionById(int id)
    {
        MovieSession movieSession = _unitOfWork.MovieSession.GetById(x => x.Id == id);
        if(movieSession != null)
        {
            ReadMovieSessionDto readMovieSessionDto = _mapper.Map<ReadMovieSessionDto>(movieSession);
            return readMovieSessionDto;
        }
        return null;
    }

    public IEnumerable<ReadMovieSessionDto> GetMovieSessionsByCinema(int cinemaId, int skip, int take)
    {
        Cinema cinema = _unitOfWork.Cinema.GetById(x => x.Id == cinemaId);
        if (cinema == null) return null;
        IEnumerable<MovieSession> movieSessions = cinema.MovieSessions.Skip(skip).Take(take).ToList();
        IEnumerable<ReadMovieSessionDto> readMovieSessionDtos = _mapper.Map<List<ReadMovieSessionDto>>(movieSessions);
        return readMovieSessionDtos;
    }

    public IEnumerable<ReadMovieSessionDto>? GetMovieSessionsByMovie(int movieId, int skip, int take)
    {
        Movie movie = _unitOfWork.Movie.GetById(x => x.Id == movieId);
        if (movie == null) return null;
        IEnumerable<MovieSession> movieSessions = movie.MovieSessions.Skip(skip).Take(take).ToList();
        IEnumerable<ReadMovieSessionDto> readMovieSessionDtos = _mapper.Map<List<ReadMovieSessionDto>>(movieSessions);
        return readMovieSessionDtos;
    }
    public IEnumerable<ReadMovieSessionDto>? GetMovieSessionsByGenre(int genreId, int skip, int take)
    {
        Genre genre = _unitOfWork.Genre.GetById(x => x.Id == genreId);
        if (genre == null) return null;
        List<MovieSession> movieSessions = new();
        foreach(MovieGenre movieGenre in genre.MovieGenres)
        {
            foreach(MovieSession movieSession in movieGenre.Movie.MovieSessions)
            {
                movieSessions.Add(movieSession);
            }
        }
        IEnumerable<ReadMovieSessionDto> readMovieSessionDtos = _mapper.Map<List<ReadMovieSessionDto>>(movieSessions);
        return readMovieSessionDtos.Skip(skip).Take(take);
    }

    public IEnumerable<ReadSeatDto> GetSeatsOfMovieSessionById(int movieSessionId)
    {
        List<Seat> seats = _unitOfWork.Seat
            .GetAll().Where(x => x.MovieSessionId == movieSessionId).ToList();
        if (seats == null) return null;
        List<ReadSeatDto> readSeatDtos = _mapper.Map<List<ReadSeatDto>>(seats);
        return readSeatDtos;
    }

    public Result PutMovieSession(int id, UpdateMovieSessionDto updateMovieSessionDto)
    {
        Movie movie = _unitOfWork.Movie.GetById(x => x.Id == updateMovieSessionDto.MovieId);
        if (movie == null) return Result.Fail("Movie not found");
        Cinema cinema = _unitOfWork.Cinema.GetById(x => x.Id == updateMovieSessionDto.CinemaId);
        if (cinema == null) return Result.Fail("Cinema not found");
        MovieSession movieSession = _unitOfWork.MovieSession.GetById(x => x.Id == id);
        if (movieSession == null) return Result.Fail("MovieSession not Found");
        _mapper.Map(updateMovieSessionDto, movieSession);
        CalculateEndTime(movieSession);
        if (CheckIfRoomIsAvailable(movieSession))
        {
            _unitOfWork.Save();
            return Result.Ok();
        }
        return null;
    }

    public Result DeleteMovieSession(int id)
    {
        MovieSession movieSession = _unitOfWork.MovieSession.GetById(x => x.Id == id);
        if (movieSession == null) return Result.Fail("MovieSession Not Found");
        _unitOfWork.MovieSession.Remove(movieSession);
        _unitOfWork.Save();
        return Result.Ok();
    }

    //public Result PatchMovieSession(int id, JsonPatchDocument<UpdateMovieSessionDto> jsonPatchDocument, ModelStateDictionary modelState)
    //{
    //    MovieSession movieSession = _unitOfWork.MovieSession.GetById(x => x.Id == id);
    //    if (movieSession == null) return null;
    //    UpdateMovieSessionDto updateMovieSessionDto = _mapper.Map<UpdateMovieSessionDto>(movieSession);
    //    jsonPatchDocument.ApplyTo(updateMovieSessionDto, modelState);
    //    if (!modelState.TryValidateModel(updateMovieSessionDto))
    //    {
    //        return Result.Fail("Fail to validate model");
    //    }
    //    _mapper.Map(updateMovieSessionDto, movieSession);
    //    _unitOfWork.Save();
    //    return Result.Ok();

    //}

    private void CalculateEndTime(MovieSession movieSession)
    {
        Movie movie = _unitOfWork.Movie.GetById(x => x.Id == movieSession.MovieId);
        movieSession.EndDateTime = movieSession.StartDateTime.AddMinutes(movie.Duration + 10);
    }

    private bool CheckIfRoomIsAvailable(MovieSession movieSession)
    {
        IList<MovieSession> movieSessionList = _unitOfWork.MovieSession.GetAll().ToList();
        movieSessionList.Remove(movieSession);        
        bool isRoomAvailable = !movieSessionList.Any(s =>
            //check if any movie session in db have the same cinema as the movie session in the parameter
            s.CinemaId == movieSession.CinemaId &&
            //check if any movie session in db have the same room number as the movie session in the parameter
            s.MovieRoomNumber == movieSession.MovieRoomNumber &&
            //check if any movie session in db have a star time that overlaps the star and end times of the movie session in the parameter
            ((s.StartDateTime >= movieSession.StartDateTime &&
            s.StartDateTime < movieSession.EndDateTime) ||
            //check if any movie session in db have a end time that overlaps the star and end times of the movie session in the parameter
            (s.EndDateTime > movieSession.StartDateTime &&
            s.EndDateTime <= movieSession.EndDateTime)));

        return isRoomAvailable;
    }   
}
