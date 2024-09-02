using System.ComponentModel.DataAnnotations;

namespace PociDelivery.Models
{
    public class Roli
    {
        [Key]
        public int IDRoli { get; set; }

        [Required]
        [StringLength(50)]
        public string EmerRoli { get; set; }

        public ICollection<Perdoruesi> Perdoruesit { get; set; } = new List<Perdoruesi>();
    }
}
