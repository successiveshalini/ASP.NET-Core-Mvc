using System.ComponentModel.DataAnnotations;

namespace MyWatch.Models
{
    public class WatchDetails
    {
        [Key]
        public int WatchId { get; set; }
        
        public string? WatchName { get; set; }
        
        public string? WatchModel { get; set; }
        
        public decimal WatchPrice { get; set; }
         
        public string? WatchColor { get; set;}



    }
}
