using System.ComponentModel.DataAnnotations;

namespace EcommerceManagementProject.Models.Domain
{
    public class CartsModel
    {
        [Key]
        public Guid CartId { get; set; }

        public int CartItems { get; set; }

        public Guid ProductRefId { get; set; }

        public ProductModel Product { get; set; }

        public Guid UserRefId { get; set; }

        public UserModel User { get; set; }
    }
}
