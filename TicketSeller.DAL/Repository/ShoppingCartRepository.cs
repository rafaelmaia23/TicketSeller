using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
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

    public override ShoppingCart? GetById(Expression<Func<ShoppingCart, bool>> expression)
    {
        return _db.ShoppingCarts
            .Include(x => x.Seats)
            .FirstOrDefault(expression);
    }

    public void Update(ShoppingCart shoppingCart)
    {
        _db.ShoppingCarts.Update(shoppingCart);
    }
}
