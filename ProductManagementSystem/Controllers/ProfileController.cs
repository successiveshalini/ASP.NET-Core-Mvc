using EcommerceManagementProject.Data;
using EcommerceManagementProject.Migrations;
using EcommerceManagementProject.Models.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EcommerceManagementProject.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        

        public ProfileController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }

       

        public   IActionResult Index( [FromRoute]string id)
        {
            var user = _applicationDbContext.Users.FirstOrDefault(x => x.Id == id);

            if (User != null)
            {
                var profile = new UserModel()
                {
                    
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Address = user.Address,
                    Password = user.Password,
                    ConfirmPassword = user.ConfirmPassword,
                    
                    
                };

                return View(profile);
            }
            else
            {
                return NotFound();
            }
        }
    }

}
    

