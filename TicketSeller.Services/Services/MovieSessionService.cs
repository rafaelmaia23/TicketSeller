using AutoMapper;
using FluentResults;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Dtos.MovieSessionDto;
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

    public ReadMovieSessionDto AddMovieSessions(CreateMovieSessionDto createMovieSessionDto)
    {
        MovieSession movieSession = _mapper.Map<MovieSession>(createMovieSessionDto);
        _unitOfWork.MovieSession.Add(movieSession);
        _unitOfWork.Save();
        //create the seats in the MovieSession
        for (char row = 'A'; row <= 'O'; row++)
        {
            for (int column = 1; column <= 10; column++)
            {
                movieSession.Seats.Add(new Seat(row, column, true, movieSession.Id));
            }
        }            
        _unitOfWork.Save();
        return _mapper.Map<ReadMovieSessionDto>(movieSession);
    }       

    public IEnumerable<ReadMovieSessionDto> GetMovieSessions()
    {
        IEnumerable<MovieSession> movieSessions = _unitOfWork.MovieSession.GetAll();
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

    public IEnumerable<ReadMovieSessionDto> GetMovieSessionsByCinema(int cinemaId)
    {
        Cinema cinema = _unitOfWork.Cinema.GetById(x => x.Id == cinemaId);
        if (cinema == null) return null;
        IEnumerable<MovieSession> movieSessions = cinema.MovieSessions.ToList();
        IEnumerable<ReadMovieSessionDto> readMovieSessionDtos = _mapper.Map<List<ReadMovieSessionDto>>(movieSessions);
        return readMovieSessionDtos;
    }

    public IEnumerable<ReadMovieSessionDto> GetMovieSessionsByMovie(int movieId)
    {
        Movie movie = _unitOfWork.Movie.GetById(x => x.Id == movieId);
        if (movie == null) return null;
        IEnumerable<MovieSession> movieSessions = movie.MovieSessions.ToList();
        IEnumerable<ReadMovieSessionDto> readMovieSessionDtos = _mapper.Map<List<ReadMovieSessionDto>>(movieSessions);
        return readMovieSessionDtos;
    }
    public IEnumerable<ReadMovieSessionDto> GetMovieSessionsByGenre(int genreId)
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
        return readMovieSessionDtos;
    }

    public Result PutMovieSession(int id, UpdateMovieSessionDto updateMovieSessionDto)
    {
        MovieSession movieSession = _unitOfWork.MovieSession.GetById(x => x.Id == id);
        if (movieSession == null) return Result.Fail("MovieSession Not Found");
        _mapper.Map(updateMovieSessionDto, movieSession);
        _unitOfWork.Save();
        return Result.Ok();
    }

    public Result DeleteMovieSession(int id)
    {
        MovieSession movieSession = _unitOfWork.MovieSession.GetById(x => x.Id == id);
        if (movieSession == null) return Result.Fail("MovieSession Not Found");
        _unitOfWork.MovieSession.Remove(movieSession);
        _unitOfWork.Save();
        return Result.Ok();
    }

}
