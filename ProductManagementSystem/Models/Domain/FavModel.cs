using System.ComponentModel.DataAnnotations;

namespace EcommerceManagementProject.Models.Domain
{
    public class FavModel
    {
        [Key]
        public Guid FavId { get; set; }
        public string UserId { get; set; }
        public Guid ProductRefId { get; set; }
    }
}
