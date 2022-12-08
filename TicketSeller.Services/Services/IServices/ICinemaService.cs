using FluentResults;
using TicketSeller.Models.Dto.CinemaDto;

namespace TicketSeller.Services.Services.IServices
{
    public interface ICinemaService
    {
        ReadCinemaDto AddCinema(CreateCinemaDto createCinemaDto);
        IEnumerable<ReadCinemaDto> GetCinemas();
        ReadCinemaDto GetCinemaById(int id);
        Result PutCinema(int id, UpdateCinemaDto updateCinemaDto);
        Result DeleteCinema(int id);
    }
}
