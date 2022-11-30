using FluentResults;
using TicketSeller.Models.Dto.MovieDto;

namespace TicketSeller.Services.IServices
{
    public interface IMovieService
    {
        ReadMovieDto AddMovie(CreateMovieDto createMovieDto);        
        IEnumerable<ReadMovieDto> GetMovies();
        ReadMovieDto GetMovieById(int id);
        Result PutMovie(int id, UpdateMovieDto updadeMovieDto);
        Result DeleteMovie(int id);
    }
}
