using FluentResults;
using TicketSeller.Models.Dtos.CinemaDto;

namespace TicketSeller.Services.Services.IServices;

public interface ICinemaService
{
    ReadCinemaDto AddCinema(CreateCinemaDto createCinemaDto);
    IEnumerable<ReadCinemaDto> GetCinemas();
    ReadCinemaDto GetCinemaById(int id);
    IEnumerable<ReadCinemaDto> GetCinemasByMovie(int movieId);
    Result PutCinema(int id, UpdateCinemaDto updateCinemaDto);
    Result DeleteCinema(int id);        
}
