namespace TicketSeller.Models.Dtos.MovieDto;

public class CustomReadMovieDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Duration { get; set; }
    public string Director { get; set; } = null!;
    public ICollection<object> MovieGenres { get; set; } = null!;
    public int Classification { get; set; }
}
