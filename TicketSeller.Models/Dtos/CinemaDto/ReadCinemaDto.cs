using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TicketSeller.Models.Dtos.AdressDto;
using Newtonsoft.Json;

namespace TicketSeller.Models.Dtos.CinemaDto;

public class ReadCinemaDto
{

    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public CustomReadAdressDto Adress { get; set; } = null!;
    [JsonIgnore]
    public ICollection<object>? MovieSessions { get; set; }
}
