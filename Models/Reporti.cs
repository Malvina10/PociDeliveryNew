using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PociDelivery.Models
{
    public class Reporti
    {
        [Key]
        public int IDReporti { get; set; }

        [ForeignKey("Perdoruesi")]
        public int IDPerdoruesi { get; set; }
        public Perdoruesi Perdoruesi { get; set; }

        [Required]
        public byte Tipi { get; set; } // 1 - Activity, 2 - Delivery, 3 - Return

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string Permbajtja { get; set; }


    }
}
