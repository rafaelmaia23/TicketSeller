using System.ComponentModel.DataAnnotations;

namespace TicketSeller.Models.Requests;

public class ConfirmUserAccountRequest
{
    [Required]
    public int UserId { get; set; }
    [Required]
    public string ConfirmUserAccountToken { get; set; } = null!;
}
