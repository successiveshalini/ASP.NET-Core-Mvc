using System.ComponentModel.DataAnnotations;

namespace EcommerceManagementProject.Models.Dto
{
    public class AddUserDto
    {
        [Required]
        [MaxLength(60, ErrorMessage = "Name should be less  then 60 characters")]
        public string FirstName { get; set; }

        public string? LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DataType(DataType.PhoneNumber)]
        public string? PhoneNo { get; set; }


        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords don't match.")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

    }
}

