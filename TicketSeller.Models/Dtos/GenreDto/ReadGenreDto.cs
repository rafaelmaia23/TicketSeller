using System.ComponentModel.DataAnnotations;

namespace TicketSeller.Models.Dtos.GenreDto;

public class ReadGenreDto
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<object> MovieGenres { get; set; }
}
