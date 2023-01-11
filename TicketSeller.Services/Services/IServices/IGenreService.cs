using FluentResults;
using TicketSeller.Models.Dtos.GenreDto;

namespace TicketSeller.Services.Services.IServices;

public interface IGenreService
{
    ReadGenreDto AddGenre(CreateGenreDto createGenreDto);
    IEnumerable<ReadGenreDto> GetGenres();
    IEnumerable<CustomReadGenreDto> GetMoviesListOfGenres();
    ReadGenreDto GetGenreById(int id);
    CustomReadGenreDto GetMoviesListOfGenreById(int movieId);
    Result PutGenre(int id, UpdateGenreDto updadeGenreDto);
    Result DeleteGenre(int id);
}
