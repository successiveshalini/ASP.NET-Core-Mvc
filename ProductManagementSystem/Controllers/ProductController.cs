using EcommerceManagementProject.Data;
using EcommerceManagementProject.Migrations;
using EcommerceManagementProject.Models.Domain;
using EcommerceManagementProject.Models.Dto;
using Microsoft.AspNetCore.Authorization;
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


        [HttpGet("id")]
        public async Task<IActionResult> GetAllByCategory(Guid categoryId, string searchingQuery, string sortOrder)
        {
            var product = await _applicationDbContext.products.Include(x => x.Category).OrderByDescending(x => x.ProductCreatedAt).ToListAsync();
            if (categoryId != Guid.Empty)
            {
                if (categoryId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                {
                    product = product.Where(x => x.Category.CategoryId == categoryId).ToList();
                }
            }
            if (!string.IsNullOrEmpty(searchingQuery))
            {
                searchingQuery = searchingQuery.ToLower();
                product = product.Where(x => x.ProductName.ToLower().Contains(searchingQuery)).ToList();
            }

            switch (sortOrder)
            {
                case "normal":
                    product = product.ToList();
                    break;
                case "asc":
                    product = product.OrderBy(x => x.ProductPrice).ToList();
                    break;
                case "desc":
                    product = product.OrderByDescending(x => x.ProductPrice).ToList();
                    break;
            }
            return PartialView("AllProductByCategory",product);
        }

        






        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ViewBag.CategoryList = await _applicationDbContext.Categories.ToListAsync();
            var products = _applicationDbContext.products.ToList();
            return View(products);

        }
        [Authorize(Roles ="Admin")]
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
        [Authorize(Roles ="Admin")]
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

                return RedirectToAction("GetAll", "Product");

            }
            return View(addProductDto);

        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var product = await _applicationDbContext.products.FirstOrDefaultAsync(x => x.ProductId == id);
            ViewBag.CategoryList = await _applicationDbContext.Categories.ToListAsync();
            if (product != null)
            {
                var newProduct = new UpdateProductDto()
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductPrice = product.ProductPrice,
                    ProductDes = product.ProductDesc,
                    IsAvailable = product.IsActive,
                    IsTrending = product.IsTrending,
                    ProductImageUrl = product.ProductImageURL,
                    CategoryRefId = product.CategoryId,
                    Category = product.Category,
                };
                return await Task.Run(() => View("Update", newProduct));
            }
            return RedirectToAction("GetAll");
        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            var product = await _applicationDbContext.products.FirstOrDefaultAsync(x => x.ProductId == updateProductDto.ProductId);
            ViewBag.CourseList = _applicationDbContext.Categories.ToList();

            string uniqueFileName = "";
            if (updateProductDto.ProductImage != null)
            {
                string uploadFoler = Path.Combine(_webHostEnvironment.WebRootPath, "image");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + updateProductDto.ProductImage.FileName;
                string filePath = Path.Combine(uploadFoler, uniqueFileName);
                updateProductDto.ProductImage.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            if (product != null)
            {
                product.ProductName = updateProductDto.ProductName;
                product.ProductPrice = updateProductDto.ProductPrice;
                product.ProductDesc = updateProductDto.ProductDes;
                product.ProductImageURL = uniqueFileName;
                product.IsActive = updateProductDto.IsAvailable;
                product.IsTrending = updateProductDto.IsTrending;
                product.CategoryId = updateProductDto.CategoryRefId;
                ViewBag.Success = "Product update Successfuly";
                TempData["error"] = "Records Updated";
            }
            await _applicationDbContext.SaveChangesAsync();
            return RedirectToAction("GetAll", "Product");
            

        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> Active(Guid id)
        {
            var product = _applicationDbContext.products.FirstOrDefault(x => x.ProductId == id);

            if (product != null)
            {
                product.IsActive = true;
                await _applicationDbContext.SaveChangesAsync();
            }
            return RedirectToAction("GetAll");
        }

        [Authorize(Roles ="Admin")]

        [HttpGet]
        public async Task<IActionResult> Deactive(Guid id)
        {
            var product = await _applicationDbContext.products.FirstOrDefaultAsync(x => x.ProductId == id);

            if (product != null)
            {
                product.IsActive = false;
                await _applicationDbContext.SaveChangesAsync();
            }
            return RedirectToAction("GetAll");
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = _applicationDbContext.products.FirstOrDefault(x => x.ProductId == id);
            if (product != null)
            {
                _applicationDbContext.products.Remove(product);
                await _applicationDbContext.SaveChangesAsync();
                TempData["message"] = "Product deleted successfully";
            }
            return RedirectToAction("GetAll");



            //    public IActionResult Index()
            //{
            //    return View();
            //}
        }
    }
}
