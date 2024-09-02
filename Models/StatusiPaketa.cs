using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PociDelivery.Models
{
    public class StatusiPaketa
    {
        [Key]
        public int IDStatusiPaketa { get; set; }

        [ForeignKey("Statusi")]
        public int IDStatusi { get; set; }
        public Statusi? Statusi { get; set; }

        [ForeignKey("Paketa")]
        public int IDPaketa { get; set; }
        public Paketa? Paketa { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public byte Fshire { get; set; } // 1 - Updated, 2 - Not Updated


    }
}
