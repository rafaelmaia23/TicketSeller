using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TicketSeller.Models.Dtos.AdressDto;

namespace TicketSeller.Models.Dtos.CinemaDto;

public class ReadCinemaDto
{

    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    [ForeignKey("Adress")]
    public int AdressId { get; set; }
    public ReadAdressDto Adress { get; set; } = null!;
    [JsonIgnore]
    public ICollection<object>? MovieSessions { get; set; }
}
