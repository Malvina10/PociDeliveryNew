using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PociDelivery.Models
{
    public class StatusiDergesa
    {
        [Key]
        public int IDStatusiDergesa { get; set; }

        [ForeignKey("Statusi")]
        public int IDStatusi { get; set; }
        public Statusi Statusi { get; set; }

        [ForeignKey("Dergesa")]
        public int IDDergesa { get; set; }
        public Dergesa Dergesa { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        public byte Fshire { get; set; } // 1 - Updated, 2 - Not Updated

    
    }
}
