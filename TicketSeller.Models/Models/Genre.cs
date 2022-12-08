using System.ComponentModel.DataAnnotations;

namespace TicketSeller.Models.Models
{
    public class Genre
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<MovieGenres> MovieGenres { get; set; }
    }
}
