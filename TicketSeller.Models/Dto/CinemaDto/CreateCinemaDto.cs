using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketSeller.Models.Dto.CinemaDto;

public class CreateCinemaDto
{
    [Required]
    [StringLength(60)]
    public string Name { get; set; }
    [ForeignKey("Adress")]
    [Required]
    public int AdressId { get; set; }
}
