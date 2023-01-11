using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSeller.Models.Dtos.GenreDto
{
    public class CustomReadGenreDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<object>? MovieGenres { get; set; }
    }
}
