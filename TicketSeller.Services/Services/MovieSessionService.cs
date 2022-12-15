using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Dto.MovieSessionDto;
using TicketSeller.Models.Models;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.Services.Services
{
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
            IEnumerable<MovieSession> movieSessions = cinema.MovieSessions.ToList();
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
}
