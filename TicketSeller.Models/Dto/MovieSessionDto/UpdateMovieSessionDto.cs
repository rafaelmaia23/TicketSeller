using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSeller.Models.Models;

namespace TicketSeller.Models.Dto.MovieSessionDto
{
    public class UpdateMovieSessionDto
    {
        [Required]
        public int MovieId { get; set; }       
        [Required]
        public int CinemaId { get; set; }
        [Required]
        public int MovieRoomNumber { get; set; }
        [Required]
        public DateTime StartDateTime { get; set; }
        [Required]
        public DateTime EndDateTime { get; set; }        
    }
}
