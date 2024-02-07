using EcommerceManagementProject.Data;
using EcommerceManagementProject.Migrations;
using EcommerceManagementProject.Models.Domain;
using EcommerceManagementProject.Models.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceManagementProject.Controllers
{
    public class FavoriteController : Controller
    {

        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        public FavoriteController(ApplicationDbContext applicationDbContext, UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        { 
            _applicationDbContext = applicationDbContext;
            _userManager = userManager; 
            _signInManager = signInManager; 

        }

        public IActionResult Index()
        {
            var userId = _signInManager.UserManager.GetUserId(User);
            var favItmes = _applicationDbContext.Favorites.Where(x => x.UserId == userId).ToList();
            var productList = _applicationDbContext.products.ToList();

            var finalList = favItmes.Join(
                                productList,
                                fav => fav.ProductRefId,
                                product => product.ProductId,
                                (fav, product) => new FavoProductDto()
                                {
                                    ProductId = product.ProductId.ToString(),
                                    ProductName = product.ProductName,
                                    ProductImageURL = product.ProductImageURL,
                                    ProductPrice = product.ProductPrice,
                                    FavId = fav.FavId,
                                    UserId = fav.UserId
                                }
                ).ToList();



            return View(finalList);

        }
        [HttpGet]
        public async Task<IActionResult> Add([FromRoute] Guid id)
        {
            if (_signInManager.IsSignedIn(User))
            {
                if (id != Guid.Empty)
                {
                    var user = _signInManager.UserManager.GetUserId(User);
                    var userid = _signInManager.UserManager.FindByIdAsync(user).Result.UserName;
                    var existingItem = _applicationDbContext.Favorites.Where(x => x.UserId == user).FirstOrDefault(x => x.ProductRefId == id);

                    if (existingItem != null)
                    {
                        TempData["favProduct"] = "This Product is Already added in Favorites";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        var newFav = new FavModel()
                        {
                            FavId = Guid.NewGuid(),
                            ProductRefId = id,
                            UserId = user,
                        };
                        await _applicationDbContext.Favorites.AddAsync(newFav);
                    }
                    await _applicationDbContext.SaveChangesAsync();

                    return RedirectToAction("Index", "Favorite");
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Authentication");
        }
        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var FavItems = _applicationDbContext.Favorites.FirstOrDefault(x => x.FavId == id);
                if (FavItems != null)
                {
                    _applicationDbContext.Favorites.Remove(FavItems);
                    await _applicationDbContext.SaveChangesAsync();
                }
            }
            TempData["cartDelete"] = "Product Removed from the Favorites";
            return RedirectToAction("Index", "Favorite");
        }


    }
    }
        


