using System.ComponentModel.DataAnnotations;

namespace PociDelivery.Models
{
    public class Statusi
    {
        [Key]
        public int IDStatusi { get; set; }

        [Required]
        [StringLength(50)]
        public string EmerStatusi { get; set; }


        public ICollection<StatusiDergesa> StatusiDergesa { get; set; }
        public ICollection<StatusiPaketa> StatusiPaketa { get; set; }
    }
}
