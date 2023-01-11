using System.ComponentModel.DataAnnotations;

namespace TicketSeller.Models.Dtos.CinemaDto;

public class CustomReadCinemaDto
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}
