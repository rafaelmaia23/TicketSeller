using System.ComponentModel.DataAnnotations;

namespace TicketSeller.Models.Dto.GenreDto;

public class UpdateGenreDto
{
    [Required]
    public string Name { get; set; }
}
