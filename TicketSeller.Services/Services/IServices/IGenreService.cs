using FluentResults;
using TicketSeller.Models.Dtos.GenreDto;

namespace TicketSeller.Services.Services.IServices;

public interface IGenreService
{
    ReadGenreDto AddGenre(CreateGenreDto createGenreDto);
    IEnumerable<ReadGenreDto> GetGenres();
    ReadGenreDto GetGenreById(int id);
    Result PutGenre(int id, UpdateGenreDto updadeGenreDto);
    Result DeleteGenre(int id);
}
