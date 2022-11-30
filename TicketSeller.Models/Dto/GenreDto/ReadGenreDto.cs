﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSeller.Models.Models;

namespace TicketSeller.Models.Dto.GenreDto
{
    public class ReadGenreDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<MovieGenres> MovieGenres { get; set; }
    }
}