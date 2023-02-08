using TicketSeller.Models.Models;

namespace TicketSeller.Models.Dtos.ShoppingCartDto;

public class CreateShoppingCartDto
{
    public int MovieSessionId { get; set; }
    public int TicketsCount { get; set; }
    public List<int> SeatsIds { get; set; }
}
