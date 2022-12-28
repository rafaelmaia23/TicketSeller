using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TicketSeller.DAL.Data;

public class UserDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
{
    public UserDbContext(DbContextOptions<UserDbContext> opt) : base(opt)
    {

    }
}
