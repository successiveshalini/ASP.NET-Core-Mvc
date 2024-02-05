using System.ComponentModel.DataAnnotations;

namespace EcommerceManagementProject.Models.Dto
{
    public class AddCategoryDto
    {
        [Required]
        public string CategoryName { get; set; }
    }
}
