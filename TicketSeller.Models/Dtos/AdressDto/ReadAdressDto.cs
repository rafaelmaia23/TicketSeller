using System.ComponentModel.DataAnnotations;
using TicketSeller.Models.Dtos.CinemaDto;

namespace TicketSeller.Models.Dtos.AdressDto;

public class ReadAdressDto
{
    [Key]
    public int Id { get; set; }
    public string Street { get; set; } = null!;
    public string Number { get; set; } = null!;
    public string? Complement { get; set; }
    public string? Reference { get; set; }
    public string ZipCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string Contry { get; set; } = null!;    
    public CustomReadCinemaDto Cinema { get; set; }
}
