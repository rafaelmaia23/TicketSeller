using System.ComponentModel.DataAnnotations;

namespace TicketSeller.Models.Dto.GenreDto
{
    public class ReadGenreDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<object> MovieGenres { get; set; }
    }
}
