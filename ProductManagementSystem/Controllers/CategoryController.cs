using EcommerceManagementProject.Data;
using EcommerceManagementProject.Models.Domain;
using EcommerceManagementProject.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceManagementProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext context;
        public CategoryController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task <IActionResult> Index()
        {
            var categoryList = await context.Categories.ToListAsync();
            return View(categoryList);
            
        }
        [HttpGet]
        public IActionResult Add()
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryDto model)
        {
            var newCategory = new CategoryModel()
            {
                CategoryName = model.CategoryName,  
            };

            await context.Categories.AddAsync(newCategory);
            await context.SaveChangesAsync();
            TempData["success"] = "Category Added Successfully";

            return RedirectToAction("Index", "Category");
        }
    }
}
