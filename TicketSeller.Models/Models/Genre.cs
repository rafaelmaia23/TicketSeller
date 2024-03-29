﻿using System.ComponentModel.DataAnnotations;

namespace TicketSeller.Models.Models;

public class Genre
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    public virtual ICollection<MovieGenre>? MovieGenres { get; set; }
}
