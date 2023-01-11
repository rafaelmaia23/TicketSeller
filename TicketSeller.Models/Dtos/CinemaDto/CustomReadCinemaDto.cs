using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TicketSeller.Models.Dtos.AdressDto;

namespace TicketSeller.Models.Dtos.CinemaDto
{
    public class CustomReadCinemaDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
