using TicketSeller.DAL.Data;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Models;

namespace TicketSeller.DAL.Repository;

public class TicketRepository : Repository<Ticket>, ITicketRepository
{
    private readonly AppDbContext _db;

    public TicketRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }
}
