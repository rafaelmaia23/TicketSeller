﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSeller.Models.Dtos.CinemaDto;

public class UpdateCinemaDto
{
    [Required]
    [StringLength(60)]
    public string Name { get; set; } = null!;
    [ForeignKey("Adress")]
    [Required]
    public int AdressId { get; set; }
}
