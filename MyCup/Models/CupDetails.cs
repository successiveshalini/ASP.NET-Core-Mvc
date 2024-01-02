using System.ComponentModel.DataAnnotations;

namespace MyCup.Models
{
    public class CupDetails
    {
        [Key]
        
        public int IdCup { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]  
        public double? Price { get; set; }
        [Required]  
        public string? Company { get; set; }
        

    }
}
