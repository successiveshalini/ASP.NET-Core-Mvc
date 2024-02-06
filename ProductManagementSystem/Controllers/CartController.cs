using EcommerceManagementProject.Data;
using EcommerceManagementProject.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceManagementProject.Controllers
{
    [Authorize(Roles = "User")]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        public IActionResult Index()
        {
            return View();
        }
    }
}
