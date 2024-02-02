using EcommerceManagementProject.Models.Domain;
using System.ComponentModel;

namespace EcommerceManagementProject.Models.Dto
{
    public class AddProductDto
    {
        public string ProductName { get; set; }

        public string? ProductDes { get; set; } // Product description

        public int ProductPrice { get; set; }

        public IFormFile? ProductImage { get; set; }

        [DefaultValue(true)]
        public bool IsAvailable { get; set; }

        [DefaultValue(false)]
        public bool IsTrending { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public DateTime ProductCreated { get; set; } = DateTime.Now;

        public CategoryModel? Category { get; set; }

        public Guid CategoryRefId { get; set; }
    }
}
