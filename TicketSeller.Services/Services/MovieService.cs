using AutoMapper;
using FluentResults;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Dto.MovieDto;
using TicketSeller.Models.Models;
using TicketSeller.Services.IServices;
using System.Linq;

namespace TicketSeller.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MovieService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ReadMovieDto AddMovie(CreateMovieDto createMovieDto)
        {
            Movie movie = _mapper.Map<Movie>(createMovieDto);
            _unitOfWork.Movie.Add(movie);
            _unitOfWork.Save();
            foreach (var id in createMovieDto.GenreIds)
            {
                MovieGenres movieGenres = new MovieGenres()
                {
                    MovieId = movie.Id,
                    Movie = movie,
                    GenreId = id,
                    Genre = _unitOfWork.Genre.GetById(id)
                };
                _unitOfWork.MovieGenres.Add(movieGenres);
                _unitOfWork.Save();
            }
            return _mapper.Map<ReadMovieDto>(movie);
        }

        public IEnumerable<ReadMovieDto> GetMovies()
        {
            IEnumerable<Movie> movies = _unitOfWork.Movie.GetAll();
            List<ReadMovieDto> readMoviesDto = _mapper.Map<List<ReadMovieDto>>(movies);
            return readMoviesDto;
        }

        public ReadMovieDto GetMovieById(int id)
        {
            Movie movie = _unitOfWork.Movie.GetById(id);
            if (movie != null)
            {
                ReadMovieDto readMovieDto = _mapper.Map<ReadMovieDto>(movie);
                return readMovieDto;
            }
            return null;
        }

        public Result PutMovie(int id, UpdateMovieDto updateMovieDto)
        {
            Movie movie = _unitOfWork.Movie.GetById(id);
            if(movie == null)
            {
                return Result.Fail("Movie Not Found");
            }
            _mapper.Map(updateMovieDto, movie);
            _unitOfWork.Save();
            return Result.Ok();
        }

        public Result DeleteMovie(int id)
        {
            Movie movie = _unitOfWork.Movie.GetById(id);
            if(movie == null)
            {
                return Result.Fail("Movie Not Found");
            }
            _unitOfWork.Movie.Remove(movie);
            _unitOfWork.Save();
            return Result.Ok();
        }
    }
}
