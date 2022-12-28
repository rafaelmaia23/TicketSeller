using Microsoft.AspNetCore.Identity;
using TicketSeller.Models.Tokens;

namespace TicketSeller.Services.Services.IServices;

public interface ILoginTokenService
{
    LoginToken CreateLoginToken(IdentityUser<int> user);
}
