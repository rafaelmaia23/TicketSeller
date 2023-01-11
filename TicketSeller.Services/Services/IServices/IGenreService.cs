using FluentResults;
using TicketSeller.Models.Dtos.GenreDto;

namespace TicketSeller.Services.Services.IServices;

public interface IGenreService
{
    ReadGenreDto AddGenre(CreateGenreDto createGenreDto);
    IEnumerable<ReadGenreDto> GetGenres(int skip, int take);
    IEnumerable<CustomReadGenreDto> GetMoviesListOfGenres(int skip, int take);
    ReadGenreDto GetGenreById(int id);
    CustomReadGenreDto GetMoviesListOfGenreById(int movieId);
    Result PutGenre(int id, UpdateGenreDto updadeGenreDto);
    Result DeleteGenre(int id);
}
