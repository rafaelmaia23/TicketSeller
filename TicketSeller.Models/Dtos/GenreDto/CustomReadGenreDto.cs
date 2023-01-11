using System.ComponentModel.DataAnnotations;

namespace TicketSeller.Models.Dtos.GenreDto;

public class CustomReadGenreDto
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<object>? MovieGenres { get; set; }
}
