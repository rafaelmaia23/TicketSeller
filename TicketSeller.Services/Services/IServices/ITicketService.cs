using FluentResults;
using TicketSeller.Models.Dtos.TicketDto;

namespace TicketSeller.Services.Services.IServices;

public interface ITicketService
{
    Result<ReadTicketDto> GetTicketById(int id, string? userId);
    Result<List<ReadTicketDto>> GetTickets(string? userId);
}
