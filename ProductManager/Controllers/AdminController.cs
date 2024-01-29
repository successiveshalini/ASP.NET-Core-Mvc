using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CustomIdentity.Controllers
{
    public class AdminController : Controller
    {
        public  IActionResult Index()
        {
           
            return View();
        }
    }
}
