using System.ComponentModel.DataAnnotations;

namespace TicketSeller.Models.Dto.GenreDto;

public class ReadGenreDto
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<object> MovieGenres { get; set; }
}
