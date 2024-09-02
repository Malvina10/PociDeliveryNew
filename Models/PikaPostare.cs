using System.ComponentModel.DataAnnotations;

namespace PociDelivery.Models
{
    public class PikaPostare
    {
        [Key]
        public int IDPikaPostare { get; set; }

        [Required (ErrorMessage ="Formati jo i sakte per emrin e pikes postare!")]
        [StringLength(100)]
        public string Pikapostare { get; set; }

        [Required(ErrorMessage = "Formati jo i sakte per adresen!")]
        [StringLength(255)]
        public string Vendndodhja { get; set; }

        [Required(ErrorMessage = "Formati jo i sakte per statusin!")]
        public byte Statusi { get; set; } // 1 - Open, 2 - Closed

        [Required(ErrorMessage = "Formati jo i sakte per daten!")]
        public DateTime CreatedOn { get; set; }

        public ICollection<Perdoruesi> Perdoruesit { get; set; } = new List<Perdoruesi>();
        public ICollection<ZonaMbulimit> ZonaMbulimit { get; set; } = new List<ZonaMbulimit>();
        public ICollection<Dergesa> Dergesat { get; set; } = new List<Dergesa>();
        public ICollection<Paketa> PaketatFillim { get; set; } = new List<Paketa>();
        public ICollection<Paketa> PaketatFund { get; set; } = new List<Paketa>();
    }
}
