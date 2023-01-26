using Microsoft.AspNetCore.Identity;
using TicketSeller.Models.Models;

namespace TicketSeller.Models.Dtos.ShoppingCartDto;

public class ReadShoppingCartDto
{
        public int Id { get; set; }
        public int MovieSessionId { get; set; }
        public MovieSession MovieSession { get; set; }
        public int TicketsCount { get; set; }
        public List<Seat> Seats { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public double TotalPrice { get; set; }
}
