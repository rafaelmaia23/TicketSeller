using System.ComponentModel.DataAnnotations;

namespace TicketSeller.Models.Dtos.MovieSessionDto;

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
    public double Price { get; set; }
}