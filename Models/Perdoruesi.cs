using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PociDelivery.Models
{
    public class Perdoruesi
    {
        [Key]
        public int IDPerdoruesi { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Fjalekalimi { get; set; }

        [Required]
        [StringLength(100)]
        public string Emri { get; set; }

        [Required]
        [StringLength(100)]
        public string Mbiemri { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [ForeignKey("Roli")]
        public int IDRoli { get; set; }
        public Roli? Roli { get; set; }

        [ForeignKey("PikaPostare")]
        public int? IDPikaPostare { get; set; }
        public PikaPostare? PikaPostare { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }


        public ICollection<Dergesa> Klient { get; set; } = new List<Dergesa>();
        public ICollection<Dergesa> Sportelist { get; set; } = new List<Dergesa>();
        public ICollection<Paketa> Paketat { get; set; } = new List<Paketa>();
        public ICollection<Reporti> Reportet { get; set; } = new List<Reporti>();
    }
}
