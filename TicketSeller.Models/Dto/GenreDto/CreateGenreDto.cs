using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSeller.Models.Dto.GenreDto
{
    public class CreateGenreDto
    {
        [Required]
        public string Name { get; set; }
    }
}
