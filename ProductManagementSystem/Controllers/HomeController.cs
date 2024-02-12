using EcommerceManagementProject.Data;
using EcommerceManagementProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EcommerceManagementProject.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _applicationDbContext;

        public HomeController(ApplicationDbContext applicationDbContext)
        {
            //_logger = logger;
           _applicationDbContext = applicationDbContext;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.CategoryList = await _applicationDbContext.Categories.ToListAsync();
            var products = _applicationDbContext.products.ToList();
            return View(products);
        }

        public IActionResult GetProductsByCategoryPriceAndName(Guid categoryId, int? priceRange, string productName)
        {
            
            var products = _applicationDbContext.products.Include(x => x.Category)
                                            .Where(x => (categoryId == Guid.Empty || x.CategoryId == categoryId) &&
                                                        (priceRange == null || x.ProductPrice <= priceRange) &&
                                                        (string.IsNullOrEmpty(productName) || x.ProductName.Contains(productName)) &&
                                                        x.IsActive == true)
                                            .OrderByDescending(x => x.ProductCreatedAt)
                                            .ToList();

            return PartialView("_ProductPartial", products);
        }
    }
}