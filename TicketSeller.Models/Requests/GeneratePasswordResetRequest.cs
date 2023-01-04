using System.ComponentModel.DataAnnotations;

namespace TicketSeller.Models.Requests;

public class GeneratePasswordResetRequest
{
    [Required]
    public string Email { get; set; }
}
