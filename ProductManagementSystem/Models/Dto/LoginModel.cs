using System.ComponentModel.DataAnnotations;

namespace EcommerceManagementProject.Models.Dto
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is required.")]

        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password should be minimum 8 character long")]
        public string? Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
