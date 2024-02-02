using System.ComponentModel;

namespace EcommerceManagementProject.Models.Dto
{
    public class ProductCategoryDto
    {
        public Guid ProductId { get; set; }

        public Guid CategoryId { get; set; }

        public string ProductName { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDes { get; set; }

        public string ProductDes { get; set; } // Product description

        public int ProductPrice { get; set; }

        public string ProductImage { get; set; }


        public bool IsActive { get; set; }

        public DateTime ProductCreated { get; set; }

        [DefaultValue(true)]
        public bool IsAvailable { get; set; }

        public bool IsTrending { get; set; }
    }
}

