using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewProject.Data;
using NewProject.Models;

namespace NewProject.Controllers
{
    public class UserController : Controller
    {
        private readonly UserDBContext _userDBContext;
        public UserController(UserDBContext userDBContext)
        { 
            _userDBContext = userDBContext;

        }
        public IActionResult Admin()
        {
            
            return View();  
        }
          
        [HttpGet]
        public IActionResult Login()
        { 
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Auth(User model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userDBContext.User.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user != null)
                {
                    if (VerifyPassword(model.Password, user.Password))
                    {
                        return RedirectToAction("Admin");

                    }

                }
                
                // Password did not match with the input email
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }


            return View("Index", model);

        }

        private bool VerifyPassword(string userPassword2, string userPassword3)
        {
            return userPassword2 == userPassword3;
        }

    }

}

