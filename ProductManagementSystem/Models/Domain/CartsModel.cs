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

        public string UserId { get; set; }

        public Guid ProductId { get; set; }

        public UserModel User { get; set; }


    }
}
