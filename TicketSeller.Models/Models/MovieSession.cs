﻿using System.ComponentModel.DataAnnotations;
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
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        [Required]
        [ForeignKey("Cinema")]
        public int CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }
        [Required]
        public int MovieRoomNumber { get; set; }
        public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
        [Required]
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}