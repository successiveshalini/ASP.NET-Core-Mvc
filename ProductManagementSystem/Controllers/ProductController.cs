using EcommerceManagementProject.Data;
using EcommerceManagementProject.Migrations;
using EcommerceManagementProject.Models.Domain;
using EcommerceManagementProject.Models.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceManagementProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ProductController(ApplicationDbContext applicationDbContext, IWebHostEnvironment webHostEnvironment)
        { 
            _applicationDbContext = applicationDbContext;   
            _webHostEnvironment = webHostEnvironment;

        }
        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            ViewBag.CategoryList = await _applicationDbContext.Categories.ToListAsync();
            var products = _applicationDbContext.products.ToList();
            return View(products);
            
        }
        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            ViewBag.CategoryList = await _applicationDbContext.Categories.ToListAsync();
            if (TempData.TryGetValue("AdminSelectedCategoryId", out var adminSelectedCategoryId))
            {
                ViewBag.DefaultCategoryId = (Guid)adminSelectedCategoryId;
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductDto addProductDto)
        {
            if (ModelState.IsValid)
            {
                string productImageurl = "";
                if (addProductDto.ProductImage != null)
                {
                    string uploadFoler = Path.Combine(_webHostEnvironment.WebRootPath, "image");
                    productImageurl = Guid.NewGuid().ToString() + "_" + addProductDto.ProductImage.FileName;
                    string filePath = Path.Combine(uploadFoler, productImageurl);
                    addProductDto.ProductImage.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                var product = new ProductModel
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = addProductDto.ProductName,
                    ProductPrice = addProductDto.ProductPrice,
                    ProductDesc = addProductDto.ProductDes!,
                    IsActive = true,
                    IsTrending = addProductDto.IsTrending, 
                    CategoryId = addProductDto.CategoryRefId,
                    ProductCreatedAt = DateTime.Now,
                    ProductImageURL = productImageurl 

                };
                _applicationDbContext.products.Add(product);
                await _applicationDbContext.SaveChangesAsync();
                ViewBag.Success = "Product Added Successfully";

                return RedirectToAction("Index", "Admin");

            }
            return View(addProductDto);  
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
