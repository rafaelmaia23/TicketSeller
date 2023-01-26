using TicketSeller.DAL.Data;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Models;

namespace TicketSeller.DAL.Repository;

public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
{
    private readonly AppDbContext _db;
    public ShoppingCartRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }
}
