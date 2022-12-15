﻿using System.ComponentModel.DataAnnotations;
using TicketSeller.Models.Models;

namespace TicketSeller.Models.Dto.MovieDto
{
    public class ReadMovieDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Director { get; set; }
        public ICollection<object> MovieGenres { get; set; }
        public int Classification { get; set; }
        public List<MovieSession> Sessions { get; set; }
    }
}
