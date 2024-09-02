using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PociDelivery.Models
{
    public class Dergesa
    {
        [Key]
        public int IDDergesa { get; set; }

        [Required]
        [StringLength(50)]
        public string Barcode { get; set; }

        [ForeignKey("Klient")]
        public int IDKlienti { get; set; }

        [ForeignKey("Sportelist")]
        public int IDSportelisti { get; set; }

        [Required]
        [StringLength(100)]
        public string EmriMarresit { get; set; }

        [Required]
        [StringLength(100)]
        public string MbiemriMarresit { get; set; }

        [Required]
        [StringLength(255)]
        public string AdresaMarresit { get; set; }

        [StringLength(20)]
        public string NumerTelefoni { get; set; }

        [StringLength(50)]
        public string Cmimi { get; set; }

        [ForeignKey("PikaPostare")]
        public int IDPikaPostare { get; set; }

       // [ForeignKey("PD_Statuset")]
        //public  int IDStatusi { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        // Navigation properties
        public Perdoruesi? Klient { get; set; }
        public Perdoruesi? Sportelist { get; set; }
        public PikaPostare? PikaPostare { get; set; }

        //public PD_Statuset Statusi { get; set; }
        public ICollection<StatusiDergesa> StatusiDergesa { get; set; } = new List<StatusiDergesa>();
    }
}
