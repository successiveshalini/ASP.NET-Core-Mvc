using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EcommerceManagementProject.Models.Domain
{
    public class UserModel : IdentityUser
    {
        public int UserId { get; set; }

        [Required]
        [MaxLength(60)]
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string? PhoneNo { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

        public string? Role { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords don't match.")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public bool IsActive { get; set; } = true;

        public virtual CartsModel Carts { get; set; }
    }
}

