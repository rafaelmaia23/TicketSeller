using TicketSeller.Models.Models;
using TicketSeller.Models.Tokens;

namespace TicketSeller.Services.Services.IServices;

public interface ILoginTokenService
{
    LoginToken CreateLoginToken(User user, string? role);
}
