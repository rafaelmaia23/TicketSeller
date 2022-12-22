using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TicketSeller.Models.Models;

namespace TicketSeller.Models.Dto.MovieDto;

public class ReadMovieDto
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public string Director { get; set; }
    public ICollection<object> MovieGenres { get; set; }
    public int Classification { get; set; }
    [JsonIgnore]
    public ICollection<object> MovieSessions { get; set; }
}
