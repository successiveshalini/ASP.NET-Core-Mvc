using EcommerceManagementProject.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceManagementProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AdminController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task <IActionResult> Index()
        {
            ViewBag.CategoryList = await _applicationDbContext.Categories.ToListAsync();
            var allProducts = await _applicationDbContext.products.ToListAsync();
            return View(allProducts);


        }
        
    }
}
