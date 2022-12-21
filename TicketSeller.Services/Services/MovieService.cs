using AutoMapper;
using FluentResults;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Dto.MovieDto;
using TicketSeller.Models.Models;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.Services.Services
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
            foreach (var id in createMovieDto.GenreIds)
            {
                MovieGenre movieGenres = new MovieGenre()
                {
                    MovieId = movie.Id,
                    Movie = movie,
                    GenreId = id,
                    Genre = _unitOfWork.Genre.GetById(x => x.Id == id)
                };
                _unitOfWork.Movie.Add(movie);
                _unitOfWork.MovieGenre.Add(movieGenres);
                _unitOfWork.Save();
            }
            return _mapper.Map<ReadMovieDto>(movie);
        }

        public IEnumerable<ReadMovieDto> GetMovies()
        {
            IEnumerable<Movie> movies = _unitOfWork.Movie.GetAll();
            IEnumerable<ReadMovieDto> readMoviesDto = _mapper.Map<List<ReadMovieDto>>(movies);
            return readMoviesDto;
        }
        public ReadMovieDto GetMovieById(int id)
        {
            Movie movie = _unitOfWork.Movie.GetById(x => x.Id == id);
            if (movie != null)
            {
                ReadMovieDto readMovieDto = _mapper.Map<ReadMovieDto>(movie);
                return readMovieDto;
            }
            return null;
        }

        public IEnumerable<ReadMovieDto> GetMoviesByGenre(int genreId)
        {
            List<MovieGenre> movieGenres = _unitOfWork.MovieGenre.GetAll().Where(x => x.GenreId == genreId).ToList();
            if (movieGenres.Count == 0) return null;
            var movies = new List<Movie>();
            foreach (MovieGenre movieGenre in movieGenres)
            {
                movies.Add(movieGenre.Movie);
            }
            IEnumerable<ReadMovieDto> readMoviesDto = _mapper.Map<List<ReadMovieDto>>(movies);
            return readMoviesDto;
        }

        public IEnumerable<ReadMovieDto> GetMoviesByCinema(int cinemaId)
        {
            List<MovieSession> movieSessions = _unitOfWork.MovieSession.GetAll().Where(x => x.CinemaId == cinemaId).ToList();
            if (movieSessions.Count == 0) return null;
            var movies = new List<Movie>();
            foreach(MovieSession movieSession in movieSessions)
            {
                if(movies.Count == 0)
                {
                    movies.Add(movieSession.Movie);
                }
                else
                {
                    bool isInList = false;
                    for(int i = 0; i< movies.Count; i++)
                    {
                        if (movieSession.Movie.Id == movies[i].Id)
                        {
                            isInList = true;
                        }
                    }
                    if(isInList == false) movies.Add(movieSession.Movie);                    
                }
            }
            IEnumerable<ReadMovieDto> readMovieDtos = _mapper.Map<List<ReadMovieDto>>(movies);
            return readMovieDtos;
        }

        public Result PutMovie(int id, UpdateMovieDto updateMovieDto)
        {
            Movie movie = _unitOfWork.Movie.GetById(x => x.Id == id);
            if (movie == null) return Result.Fail("Movie Not Found");            
            ICollection<MovieGenre> NewMovieGenres = new List<MovieGenre>();
            foreach(var genreId in updateMovieDto.GenreIds)
            {
                Genre newGenre = _unitOfWork.Genre.GetById(x => x.Id == genreId);
                if (newGenre == null) return Result.Fail("Genre Not Found");
                MovieGenre movieGenres = new MovieGenre
                {
                    GenreId = genreId,
                    Genre = newGenre,
                    MovieId = movie.Id,
                    Movie = movie
                };
                NewMovieGenres.Add(movieGenres);
            }            
            _mapper.Map(updateMovieDto, movie);
            movie.MovieGenres = NewMovieGenres;
            _unitOfWork.Save();
            return Result.Ok();
        }

        public Result DeleteMovie(int id)
        {
            Movie movie = _unitOfWork.Movie.GetById(x => x.Id == id);
            if (movie == null) return null;
            if (movie.MovieSessions.Count != 0) return Result.Fail("Cannot delete a Movie that have MovieSessions");
            _unitOfWork.Movie.Remove(movie);
            _unitOfWork.Save();
            return Result.Ok();
        }
       
    }
}
