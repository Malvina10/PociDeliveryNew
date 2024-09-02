using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PociDelivery.Models
{
    public class Paketa
    {
        [Key]
        public int IDPaketa { get; set; }

        [Required]
        [StringLength(50)]
        public string Barcode { get; set; }

        [ForeignKey("Transportuesi")]
        public int IDTransportuesi { get; set; }
        public Perdoruesi? Transportuesi { get; set; }

        [ForeignKey("PikaPostareFillim")]
        public int IDPikaPostareFillim { get; set; }
        public PikaPostare? PikaPostareFillim { get; set; }

        [ForeignKey("PikaPostareFund")]
        public int IDPikaPostareFund { get; set; }
        public PikaPostare? PikaPostareFund { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }


        public ICollection<StatusiPaketa> StatusiPaketa { get; set; } = new List<StatusiPaketa>();
    }
}
