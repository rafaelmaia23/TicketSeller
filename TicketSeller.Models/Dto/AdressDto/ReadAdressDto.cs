using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TicketSeller.Models.Models;

namespace TicketSeller.Models.Dto.AdressDto
{
    public class ReadAdressDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Street { get; set; }
        [Required]
        [StringLength(10)]
        public string Number { get; set; }
        [StringLength(150)]
        public string Complement { get; set; }
        [StringLength(200)]
        public string Reference { get; set; }
        [Required]
        [StringLength(8)]
        public string ZipCode { get; set; }
        [Required]
        [StringLength(100)]
        public string City { get; set; }
        [Required]
        [StringLength(80)]
        public string State { get; set; }
        [Required]
        [StringLength(80)]
        public string Contry { get; set; }
        [Required]        
        public Cinema Cinema { get; set; }
    }
}
