using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketSeller.Models.Dtos.SeatDto;

public class ReadSeatDto
{
    [Key]
    public int Id { get; set; }
    public char Row { get; set; }
    public int Column { get; set; }
    public string Name => $"{Row}{Column}";
    public bool IsAvailable { get; set; }
    [ForeignKey("MovieSession")]
    public int MovieSessionId { get; set; }
}
