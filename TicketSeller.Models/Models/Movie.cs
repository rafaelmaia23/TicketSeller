using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSeller.Models.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(1,600)]
        public int Duration { get; set; }
        [Required]
        public string Director { get; set; }
        public ICollection<MovieGenres> MovieGenres { get; set; }
        [Required]
        public int Classification { get; set; }

    }
}
