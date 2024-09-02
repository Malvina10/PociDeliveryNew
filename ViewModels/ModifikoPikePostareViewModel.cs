using PociDelivery.Models;
using System.ComponentModel.DataAnnotations;

namespace PociDelivery.ViewModels
{
    public class ModifikoPikePostareViewModel
    {
        public int IDPikaPostare { get; set; }
        public string Pikapostare { get; set; }
        public string Vendndodhja { get; set; }

        public byte Statusi { get; set; } // 1 - Open, 2 - Closed

        public DateTime CreatedOn { get; set; }

        public ICollection<Perdoruesi> Perdoruesit { get; set; } = new List<Perdoruesi>();
        public ICollection<ZonaMbulimit> ZonaMbulimit { get; set; } = new List<ZonaMbulimit>();
        public ICollection<Dergesa> Dergesat { get; set; } = new List<Dergesa>();
        public ICollection<Paketa> PaketatFillim { get; set; } = new List<Paketa>();
        public ICollection<Paketa> PaketatFund { get; set; } = new List<Paketa>();
    }
}
