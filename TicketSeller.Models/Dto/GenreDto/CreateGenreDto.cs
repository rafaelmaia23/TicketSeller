using System.ComponentModel.DataAnnotations;

namespace TicketSeller.Models.Dto.GenreDto;

public class CreateGenreDto
{
    [Required]
    public string Name { get; set; }
}
