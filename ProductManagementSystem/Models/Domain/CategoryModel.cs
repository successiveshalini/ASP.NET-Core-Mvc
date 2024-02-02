using System.ComponentModel.DataAnnotations;

namespace EcommerceManagementProject.Models.Domain
{
    public class CategoryModel
    {
        [Key]
        public Guid CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public ICollection<ProductModel> Products { get; set; }
    }
}
