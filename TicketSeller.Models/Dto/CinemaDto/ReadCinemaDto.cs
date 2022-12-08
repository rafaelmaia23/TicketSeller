using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSeller.Models.Models;

namespace TicketSeller.Models.Dto.CinemaDto
{
    public class ReadCinemaDto
    {

        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Name { get; set; }
        [ForeignKey("Adress")]
        [Required]
        public int AdressId { get; set; }
        [Required]
        public Adress Adress { get; set; }
    }
}
