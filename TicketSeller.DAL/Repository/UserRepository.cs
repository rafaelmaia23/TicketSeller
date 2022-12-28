using TicketSeller.DAL.Data;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Models;

namespace TicketSeller.DAL.Repository;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly AppDbContext _db;
    public UserRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }
}
