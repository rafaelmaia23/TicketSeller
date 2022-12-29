using System.ComponentModel.DataAnnotations;

namespace TicketSeller.Models.Models;

public class Movie
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    [Required]
    [Range(1,600)]
    public int Duration { get; set; }
    [Required]
    public string Director { get; set; } = null!;
    public virtual ICollection<MovieGenre> MovieGenres { get; set; } = null!;
    [Required]
    public int Classification { get; set; }
    public virtual List<MovieSession>? MovieSessions { get; set; }

}
