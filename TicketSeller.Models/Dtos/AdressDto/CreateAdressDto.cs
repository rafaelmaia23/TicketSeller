using System.ComponentModel.DataAnnotations;

namespace TicketSeller.Models.Dtos.AdressDto;

public class CreateAdressDto
{
    [Required]
    [StringLength(150)]
    public string Street { get; set; } = null!;
    [Required]
    [StringLength(10)]
    public string Number { get; set; } = null!;
    [StringLength(150)]
    public string? Complement { get; set; }
    [StringLength(200)]
    public string? Reference { get; set; }
    [Required]
    [StringLength(8)]
    public string ZipCode { get; set; } = null!;
    [Required]
    [StringLength(100)]
    public string City { get; set; } = null!;
    [Required]
    [StringLength(80)]
    public string State { get; set; } = null!;
    [Required]
    [StringLength(80)]
    public string Contry { get; set; } = null!;
}
