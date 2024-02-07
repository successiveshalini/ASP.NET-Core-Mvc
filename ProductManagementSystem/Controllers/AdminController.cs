using EcommerceManagementProject.Data;
using EcommerceManagementProject.Models.Domain;
using EcommerceManagementProject.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceManagementProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private SignInManager<UserModel> signInManager;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<UserModel> userManager;

        public AdminController(SignInManager<UserModel> signInManager, UserManager<UserModel> userManager, ApplicationDbContext applicationDbContext)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            _applicationDbContext = applicationDbContext;  
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.CategoryList = await _applicationDbContext.Categories.ToListAsync();
            var allProducts = await _applicationDbContext.products.ToListAsync();
            return View(allProducts);


        }
        [HttpGet]
        public IActionResult GetAllUser()
        {
            var allUsers = userManager.Users.Where(x => !x.Email.Contains("admin")).ToList();
            return View(allUsers);
        }


        public IActionResult UpdateUser(string id)
        {
            var user = userManager.Users.FirstOrDefault(x => x.Id == id);
            var finalUser = new UpdateUserDto()
            {
                userId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                Password = user.Password,
                ConfirmPassword = user.ConfirmPassword,

            };
            return View(finalUser);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);

            }
            var existingUser = userManager.Users.FirstOrDefault(x => x.Id == model.Id);
            if (existingUser == null)
            {
                return View(model);
            }

            var OldPassword = existingUser.Password;
            var NewPassword = model.Password;
            existingUser.FirstName = model.FirstName;
            existingUser.LastName = model.LastName;
            existingUser.Address = model.Address;
            existingUser.Email = model.Email;

            var resultPassword = await userManager.ChangePasswordAsync(existingUser, OldPassword, NewPassword);
            if (resultPassword.Succeeded)
            {
                existingUser.Password = NewPassword;

                await userManager.UpdateAsync(existingUser);
            }


            _applicationDbContext.SaveChanges();
            TempData["usersuccess"] = "User Updated Successfully";
            return RedirectToAction("GetAllUser", "Admin");
        }
        //[HttpGet]
        //public IActionResult ChangePassword()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
        //{
        //    var user = await userManager.GetUserAsync(User);

        //    if (user != null)
        //    {
        //        var result = await userManager.ChangePasswordAsync(user, changePasswordDto.OldPassword, changePasswordDto.NewPassword);
        //        if (result.Succeeded)
        //        {
        //            user.Password = changePasswordDto.NewPassword;
        //            user.ConfirmPassword = changePasswordDto.NewPassword;

        //            await userManager.UpdateAsync(user);
        //            ModelState.Clear();
        //            return RedirectToAction("GetAllUser", "Admin");
        //        }
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError("", error.Description);
        //        }


        //    }
        //    return View(changePasswordDto);
        //}




        [HttpGet]
        public IActionResult DeactiveUser(string id)
        {
            var user = userManager.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            user.IsActive = false;
            _applicationDbContext.SaveChanges();
            return RedirectToAction("GetAllUser", "Admin");
        }
        [HttpGet]
        public IActionResult ActivateUser(string id)
        {
            var user = userManager.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            user.IsActive = true;
            _applicationDbContext.SaveChanges();
            return RedirectToAction("GetAllUser", "Admin");
        }

    }


}


