using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSeller.Models.Models;

public class ShoppingCart
{
    public int Id { get; set; }
    [ForeignKey("MovieSession")]
    public int MovieSessionId { get; set; }
    public virtual MovieSession MovieSession { get; set; }
    public int TicketsCount { get; set; }
    public virtual List<Seat> Seats { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public double TotalPrice { get; set; }

}
