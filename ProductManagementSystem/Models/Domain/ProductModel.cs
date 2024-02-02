using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceManagementProject.Models.Domain
{
    public class ProductModel
    {
        [Key]
        public Guid ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string ProductDesc { get; set; }

        [Required]
        public int ProductPrice { get; set; }

        public DateTime ProductCreatedAt { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; } = true;

        public bool IsTrending { get; set; } = false;

        public string ProductImageURL { get; set; }

        public Guid CategoryId { get; set; }

        // navigation property
        [ForeignKey("CategoryId")]
        public CategoryModel Category { get; set; }
    }   
}

