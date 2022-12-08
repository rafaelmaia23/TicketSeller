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

        //public IEnumerable<ReadMovieDto> GetMovies(int? genreId)
        //{
        //    IEnumerable<Movie> movies;
        //    if (genreId == null)
        //    {
        //        movies = _unitOfWork.Movie.GetAll();
        //    }
        //    else
        //    {
        //        List<MovieGenres> movieGenres = _unitOfWork.MovieGenres.GetAll().Where(x => x.GenreId == genreId).ToList();
        //        if (movieGenres.Count == 0) return null;
        //        var movieList = new List<Movie>();
        //        foreach (MovieGenres movieGenre in movieGenres)
        //        {
        //            movieList.Add(movieGenre.Movie);
        //        }
        //        movies = movieList;

        //    }
        //    List<ReadMovieDto> readMoviesDto = _mapper.Map<List<ReadMovieDto>>(movies);
        //    return readMoviesDto;
        //}
        public IEnumerable<ReadMovieDto> GetMovies()
        {
            IEnumerable<Movie> movies = _unitOfWork.Movie.GetAll();
            IEnumerable<ReadMovieDto> readMoviesDto = _mapper.Map<List<ReadMovieDto>>(movies);
            return readMoviesDto;
        }

        public IEnumerable<ReadMovieDto> GetMoviesByGenre(int genreId)
        {            
            List<MovieGenres> movieGenres = _unitOfWork.MovieGenres.GetAll().Where(x => x.GenreId == genreId).ToList();
            if (movieGenres.Count == 0) return null;
            List<Movie> movies = new List<Movie>();
            foreach (MovieGenres movieGenre in movieGenres)
            {
                movies.Add(movieGenre.Movie);
            }
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
            if (movie == null) return Result.Fail("Movie Not Found");            
            ICollection<MovieGenres> NewMovieGenres = new List<MovieGenres>();
            foreach(var genreId in updateMovieDto.GenreIds)
            {
                Genre newGenre = _unitOfWork.Genre.GetById(genreId);
                if (newGenre == null) return Result.Fail("Genre Not Found");
                MovieGenres movieGenres = new MovieGenres
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
            Movie movie = _unitOfWork.Movie.GetById(id);
            if(movie == null) return Result.Fail("Movie Not Found");
            //foreach(MovieGenres movieGenres in movie.MovieGenres)
            //{
            //    _unitOfWork.
            //}
            _unitOfWork.Movie.Remove(movie);
            _unitOfWork.Save();
            return Result.Ok();
        }
    }
}
