using TicketSeller.DAL.Data;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Models;

namespace TicketSeller.DAL.Repository;

public class SeatRepository : Repository<Seat>, ISeatRepository
{
    private readonly AppDbContext _db;

	public SeatRepository(AppDbContext db): base(db)
	{
		_db = db;
	}
}
