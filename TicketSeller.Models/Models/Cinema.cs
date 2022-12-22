using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSeller.Models.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(60)]
    public string Name { get; set; }
    [ForeignKey("Adress")]
    [Required]
    public int AdressId { get; set; }
    public virtual Adress Adress { get; set; }
    public virtual List<MovieSession> MovieSessions { get; set; }
}
