using System.ComponentModel.DataAnnotations;

namespace TicketSeller.Models.Dtos.GenreDto;

public class CreateGenreDto
{
    [Required]
    public string Name { get; set; }
}
