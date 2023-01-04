using Microsoft.AspNetCore.Identity;
using TicketSeller.Models.Models;

namespace TicketSeller.DAL.Repository.IRepository;

public interface IUserRepository : IRepository<User>
{
    IdentityUser<int>? GetIdentityUserByEmail(string email);
}
