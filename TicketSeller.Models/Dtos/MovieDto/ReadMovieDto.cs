using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TicketSeller.Models.Models;

namespace TicketSeller.Models.Dtos.MovieDto;

public class ReadMovieDto
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Duration { get; set; }
    public string Director { get; set; } = null!;
    public ICollection<object> MovieGenres { get; set; } = null!;
    public int Classification { get; set; }
    [JsonIgnore]
    public ICollection<object>? MovieSessions { get; set; }
}
