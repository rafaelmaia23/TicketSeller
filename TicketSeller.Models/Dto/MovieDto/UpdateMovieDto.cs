using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSeller.Models.Models;

namespace TicketSeller.Models.Dto.MovieDto
{
    public class UpdateMovieDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(1, 600)]
        public int Duration { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public ICollection<MovieGenres> MovieGenres { get; set; }
        [Required]
        public int Classification { get; set; }
    }
}
