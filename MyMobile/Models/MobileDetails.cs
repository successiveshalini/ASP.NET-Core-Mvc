using System.ComponentModel.DataAnnotations;

namespace MyMobile.Models
{
    public class MobileDetails
    {
        [Key]
        public int MobId { get; set; }
        [Required]
        public string? MobName { get; set;}
        [Required]
        public string? MobModel { get; set;}
        [Required]
        public decimal MobPrice { get; set;}
         
    }
}
