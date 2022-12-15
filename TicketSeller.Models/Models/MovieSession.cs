using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TicketSeller.Models.Models
{
    public class MovieSession
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public virtual Movie Movie { get; set; }
        [Required]
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        [Required]
        public virtual Cinema Cinema { get; set; }
        [Required]
        [ForeignKey("Cinema")]
        public int CinemaId { get; set; }
        [Required]
        public DateTime StartDateTime { get; set; }
        [Required]
        public DateTime EndDateTime { get; set; }
        [Required]
        public int MovieRoomNumber { get; set; }
        [JsonIgnore]
        public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();

        public MovieSession()
        {
            Seats = new List<Seat>();

            for(char row = 'A'; row <= 'O'; row++)
            {
                for(int column = 1; column <= 10; column++)
                {
                    Seats.Add(new Seat(row, column, true, this.Id));
                }
            }
        }
    }
}
