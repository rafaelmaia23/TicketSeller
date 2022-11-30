using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSeller.Models.Dto.GenreDto;
using TicketSeller.Models.Dto.MovieDto;

namespace TicketSeller.Services.Services.IServices
{
    public interface IGenreService
    {
        ReadGenreDto AddGenre(CreateGenreDto createGenreDto);
        IEnumerable<ReadGenreDto> GetGenres();
        ReadGenreDto GetGenreById(int id);
        Result PutGenre(int id, UpdateGenreDto updadeGenreDto);
        Result DeleteGenre(int id);
    }
}
