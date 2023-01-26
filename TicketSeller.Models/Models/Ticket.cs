using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSeller.Models.Models;

public class Ticket
{
    public int Id { get; set; }
    [ForeignKey("MovieSession")]
    public int MovieSessionId { get; set; }
    public virtual MovieSession MovieSession { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public virtual User User { get; set; }
    [ForeignKey("Seat")]
    public int SeatId { get; set; }
    public virtual Seat Seat { get; set; }
    public DateTime Date { get; set; }
    public bool IsUsed { get; set; } = false;
}
