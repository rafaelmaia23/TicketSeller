using System.ComponentModel.DataAnnotations.Schema;
using TicketSeller.Models.Dtos.MovieSessionDto;
using TicketSeller.Models.Models;

namespace TicketSeller.Models.Dtos.TicketDto;

public class ReadTicketDto
{
    public int Id { get; set; }
    [ForeignKey("MovieSession")]
    public int MovieSessionId { get; set; }
    public virtual ReadMovieSessionDto MovieSession { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; }
    [ForeignKey("Seat")]
    public int SeatId { get; set; }
    public string SeatName { get; set; }
    public DateTime Date { get; set; }
    public bool IsUsed { get; set; } = false;
}
