using EcommerceManagementProject.Data;
using EcommerceManagementProject.Migrations;
using EcommerceManagementProject.Models.Domain;
using EcommerceManagementProject.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceManagementProject.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        public CartController(ApplicationDbContext applicationDbContext, UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var userId = _signInManager.UserManager.GetUserId(User);
            var cartItems = _applicationDbContext.Carts.Where(x => x.UserId == userId).ToList();
            var productList = _applicationDbContext.products.ToList();

            /*var finalList = cartItems.Join(
                                productList,
                                cart => cart.ProductRefId,
                                product => product.ProductId,
                                (cart, product) => new CartProductDto()
                                {
                                    ProductId = product.ProductId,
                                    ProductName = product.ProductName,
                                    ProductImageURL = product.ProductImageURL,
                                    ProductPrice = product.ProductPrice,
                                    CartId = cart.CartId,
                                    UserId = cart.UserRefId.ToString()
                                }
                ).ToList();*/

            var cartItemsList = _applicationDbContext.Carts.Include(x=>x.Product).ToList();


            return View(cartItemsList);







        }
        [HttpGet]
        public async Task<IActionResult> AddToCart([FromRoute] Guid id)
        {
            if (_signInManager.IsSignedIn(User))
            {
                if (id != Guid.Empty)
                {
                    var user = _signInManager.UserManager.GetUserId(User);
                    //var userId = _signInManager.UserManager.FindByIdAsync(user).Result;
                    var existingcart = _applicationDbContext.Carts.Where(x => x.UserId == user).FirstOrDefault(x=>x.ProductId==id);

                    if (existingcart != null)
                    {
                        existingcart.CartItems++;

                    }
                    else
                    {
                        var newcart = new CartsModel()
                        {
                            CartId = Guid.NewGuid(), 
                            CartItems = 1,
                            ProductId=id,
                            UserId=user,
                        };
                        await _applicationDbContext.Carts.AddAsync(newcart);  
                        

                    }
                    await _applicationDbContext.SaveChangesAsync(); 
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index", "Home");
                    
            

            }
            return RedirectToAction("Login", "Authentication");

        }
        [HttpGet]
        public async Task<IActionResult> OrderDelete([FromRoute]Guid id)
        {
            if (id != Guid.Empty)
            {
                var CartItems = _applicationDbContext.Carts.FirstOrDefault(x => x.CartId == id);
                if (CartItems != null)
                {
                    _applicationDbContext.Carts.Remove(CartItems);
                    await _applicationDbContext.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index");


        }
    }
}
