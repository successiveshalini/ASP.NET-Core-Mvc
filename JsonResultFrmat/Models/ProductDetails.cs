using System.ComponentModel.DataAnnotations;

namespace JsonResultFormate.Models
{
    public class ProductDetails
    {
        [Key]
        public int ProductId { get; set; }  
        public string? ProductName { get; set; } 
        public string? Description { get; set;}
        
    }
}
