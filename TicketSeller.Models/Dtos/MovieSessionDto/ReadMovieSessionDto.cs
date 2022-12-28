using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TicketSeller.Models.Models;
using System.Text.Json.Serialization;
using TicketSeller.Models.Dtos.MovieDto;
using TicketSeller.Models.Dtos.CinemaDto;

namespace TicketSeller.Models.Dtos.MovieSessionDto;

public class ReadMovieSessionDto
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Movie")]
    public int MovieId { get; set; }
    public ReadMovieDto Movie { get; set; }
    [ForeignKey("Cinema")]
    public int CinemaId { get; set; }
    public ReadCinemaDto Cinema { get; set; }
    public int MovieRoomNumber { get; set; }
    [JsonIgnore]
    public virtual ICollection<Seat> Seats { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    
}
