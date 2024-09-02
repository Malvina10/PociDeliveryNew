using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PociDelivery.Models
{
    public class ZonaMbulimit
    {
        [Key]
        public int IDZonaMbulimit { get; set; }

        [ForeignKey("PikaPostare")]
        public int IDPikaPostare { get; set; }
        public PikaPostare? PikaPostare { get; set; }

        [Required]
        [StringLength(100)]
        public string Zona { get; set; }

        [Required]
        public byte Statusi { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
  
    }
}
