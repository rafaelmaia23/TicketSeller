using System.ComponentModel.DataAnnotations;

namespace TicketSeller.Models.Dto.MovieSessionDto;

public class UpdateMovieSessionDto
{
    [Required]
    public int MovieId { get; set; }
    [Required]
    public int CinemaId { get; set; }
    [Required]
    public int MovieRoomNumber { get; set; }
    [Required]
    public DateTime StartDateTime { get; set; }
    [Required]
    public DateTime EndDateTime { get; set; }
}