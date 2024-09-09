using PociDelivery.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PociDelivery.ViewModels
{
    public class PerdoruesitViewModel
    {
        public int IDPerdoruesi { get; set; }

        public string Username { get; set; }

        public string Fjalekalimi { get; set; }

        public string Emri { get; set; }

        public string Mbiemri { get; set; }

        public string Email { get; set; }

 
        public string PhoneNumber { get; set; }

        public int IDRoli { get; set; }
        public Roli? Roli { get; set; }

        public int? IDPikaPostare { get; set; }
        public PikaPostare? PikaPostare { get; set; }

        public DateTime CreatedOn { get; set; }


        public ICollection<Dergesa> Klient { get; set; } = new List<Dergesa>();
        public ICollection<Dergesa> Sportelist { get; set; } = new List<Dergesa>();
        public ICollection<Paketa> Paketat { get; set; } = new List<Paketa>();
        public ICollection<Reporti> Reportet { get; set; } = new List<Reporti>();
    }

}
