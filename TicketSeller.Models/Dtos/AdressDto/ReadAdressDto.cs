using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TicketSeller.Models.Dtos.CinemaDto;

namespace TicketSeller.Models.Dtos.AdressDto;

public class ReadAdressDto
{
    [Key]
    public int Id { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string Complement { get; set; }
    public string Reference { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Contry { get; set; }
    [JsonIgnore]
    public ReadCinemaDto Cinema { get; set; }
}
