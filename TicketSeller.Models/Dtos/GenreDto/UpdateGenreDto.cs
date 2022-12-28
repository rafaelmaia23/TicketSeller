using System.ComponentModel.DataAnnotations;

namespace TicketSeller.Models.Dtos.GenreDto;

public class UpdateGenreDto
{
    [Required]
    public string Name { get; set; }
}
