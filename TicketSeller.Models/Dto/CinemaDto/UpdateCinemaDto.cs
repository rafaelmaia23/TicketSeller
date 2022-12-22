using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSeller.Models.Dto.CinemaDto;

public class UpdateCinemaDto
{
    [Required]
    [StringLength(60)]
    public string Name { get; set; }
    [ForeignKey("Adress")]
    [Required]
    public int AdressId { get; set; }
}
