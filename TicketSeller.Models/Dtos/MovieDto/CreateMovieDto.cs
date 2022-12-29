using System.ComponentModel.DataAnnotations;

namespace TicketSeller.Models.Dtos.MovieDto;

public class CreateMovieDto
{
    [Required]
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    [Required]
    [Range(1, 600)]
    public int Duration { get; set; }
    [Required]
    public string Director { get; set; } = null!;
    [Required]
    public List<int> GenreIds { get; set; } = null!;
    [Required]
    public int Classification { get; set; }
}
