using FluentResults;
using TicketSeller.Models.Requests;

namespace TicketSeller.Services.Services.IServices;

public interface ILoginService
{
    Result LoginUser(LoginRequest loginRequest);
}
