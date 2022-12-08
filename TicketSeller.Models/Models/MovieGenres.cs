using System.ComponentModel.DataAnnotations;

namespace TicketSeller.Models.Models
{
    public class MovieGenres
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public virtual Movie Movie { get; set; }
        [Required]
        public int GenreId { get; set; }
        [Required]
        public virtual Genre Genre { get; set; }
    }
}
