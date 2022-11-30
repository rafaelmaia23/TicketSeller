using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSeller.Models.Models
{
    public class Genre
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //public virtual ICollection<Movie> Movies { get; set; }
        public ICollection<MovieGenres> MovieGenres { get; set; }
    }
}
