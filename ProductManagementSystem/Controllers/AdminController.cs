using EcommerceManagementProject.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceManagementProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    { 
        public  IActionResult Index()
        {
            
            return View();
        }
        
    }
}
