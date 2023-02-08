using TicketSeller.Models.Models;

namespace TicketSeller.DAL.Repository.IRepository;

public interface IShoppingCartRepository : IRepository<ShoppingCart>
{
    void Update(ShoppingCart shoppingCart);
}
