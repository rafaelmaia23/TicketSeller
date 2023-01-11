using FluentResults;
using TicketSeller.Models.Dtos.CinemaDto;

namespace TicketSeller.Services.Services.IServices;

public interface ICinemaService
{
    Result<ReadCinemaDto> AddCinema(CreateCinemaDto createCinemaDto);
    IEnumerable<ReadCinemaDto> GetCinemas(int skip, int take);
    ReadCinemaDto GetCinemaById(int id);
    IEnumerable<ReadCinemaDto> GetCinemasByMovie(int movieId, int skip, int take);
    Result PutCinema(int id, UpdateCinemaDto updateCinemaDto);
    Result DeleteCinema(int id);        
}
