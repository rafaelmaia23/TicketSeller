using System.ComponentModel.DataAnnotations;

namespace TicketSeller.Models.Models;

public class MovieGenre
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public int MovieId { get; set; }
    public virtual Movie Movie { get; set; }
    [Required]
    public int GenreId { get; set; }
    public virtual Genre Genre { get; set; }
}
