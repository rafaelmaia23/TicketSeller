using Microsoft.AspNetCore.Identity;
using TicketSeller.Models.Dtos.MovieSessionDto;
using TicketSeller.Models.Dtos.SeatDto;
using TicketSeller.Models.Models;

namespace TicketSeller.Models.Dtos.ShoppingCartDto;

public class ReadShoppingCartDto
{
        public int Id { get; set; }
        public int MovieSessionId { get; set; }
        public ReadMovieSessionDto MovieSession { get; set; }
        public int TicketsCount { get; set; }
        public List<ReadSeatDto> Seats { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public double TotalPrice { get; set; }
}
