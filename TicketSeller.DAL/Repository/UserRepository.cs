using Microsoft.AspNetCore.Identity;
using TicketSeller.DAL.Data;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Models;

namespace TicketSeller.DAL.Repository;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly AppDbContext _db;
    private readonly SignInManager<IdentityUser<int>> _signInManager;
    public UserRepository(AppDbContext db, SignInManager<IdentityUser<int>> signInManager) : base(db)
    {
        _db = db;
        _signInManager = signInManager;
    }

    public IdentityUser<int>? GetIdentityUserByEmail(string email)
    {
        return _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(user =>
                    user.NormalizedEmail == email.ToUpper());
    }
}
