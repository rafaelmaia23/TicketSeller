using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSeller.Models.Models;

namespace TicketSeller.Models.Dto.MovieDto
{
    public class ReadMovieDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Director { get; set; }
        //public object MovieGenres { get; set; }
        public ICollection<MovieGenres> MovieGenres { get; set; }
        public int Classification { get; set; }
    }
}
