using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSeller.Models.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Name { get; set; }
        [ForeignKey("Adress")]
        [Required]
        public int AdressId { get; set; }
        [Required]
        public virtual Adress Adress { get; set; }
    }
}
