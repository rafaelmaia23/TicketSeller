using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TicketSeller.Models.Models
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }
        public char Row { get; set; }
        public int Column { get; set; }
        public string Name => $"{Row}{Column}";
        public bool IsAvailable { get; set; }
        [ForeignKey("MovieSession")]
        public int MovieSessionId { get; set; }
        [JsonIgnore]
        public virtual MovieSession MovieSession { get; set; }

        public Seat(char row, int column, bool isAvailable, int movieSessionId)
        {
            Row = row;
            Column = column;
            IsAvailable = isAvailable;
            MovieSessionId = movieSessionId;
        }
    }
}
