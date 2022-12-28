using FluentResults;
using TicketSeller.Models.Dtos.MovieDto;

namespace TicketSeller.Services.Services.IServices;

public interface IMovieService
{
    ReadMovieDto AddMovie(CreateMovieDto createMovieDto);
    IEnumerable<ReadMovieDto> GetMovies();
    IEnumerable<ReadMovieDto> GetMoviesByGenre(int genreId);
    ReadMovieDto GetMovieById(int id);
    IEnumerable<ReadMovieDto> GetMoviesByCinema(int cinemaId);
    Result PutMovie(int id, UpdateMovieDto updadeMovieDto);
    Result DeleteMovie(int id);
}
