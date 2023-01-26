using Microsoft.AspNetCore.Identity;

namespace TicketSeller.Models.Models;

public class User : IdentityUser<int>
{
    public virtual List<Ticket> Tickets { get; set; }
}
