using FluentResults;
using TicketSeller.Models.Dtos.MovieDto;

namespace TicketSeller.Services.Services.IServices;

public interface IMovieService
{
    ReadMovieDto AddMovie(CreateMovieDto createMovieDto);
    IEnumerable<ReadMovieDto> GetMovies(int skip, int take);
    IEnumerable<ReadMovieDto> GetMoviesByGenre(int genreId, int skip, int take);
    ReadMovieDto GetMovieById(int id);
    IEnumerable<ReadMovieDto> GetMoviesByCinema(int cinemaId, int skip, int take);
    Result PutMovie(int id, UpdateMovieDto updadeMovieDto);
    Result DeleteMovie(int id);
}
