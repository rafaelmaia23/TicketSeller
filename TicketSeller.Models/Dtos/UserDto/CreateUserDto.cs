using System.ComponentModel.DataAnnotations;

namespace TicketSeller.Models.Dtos.UserDto;

public class CreateUserDto
{
    [Required]
    public string Username { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    [Required]
    [Compare("Password")]
    public string RePassword { get; set; } = null!;
}
