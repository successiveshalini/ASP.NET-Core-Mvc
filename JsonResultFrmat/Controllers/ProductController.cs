using JsonResultFormate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace JsonResultFormate.Controllers
{
    public class ProductController : Controller
    {
        

       // public object ProductId { get;  set; }

        public JsonResult Index()
        {
            var convert = new JsonSerializerOptions();
            convert.PropertyNameCaseInsensitive = true; 
            List<ProductDetails> products = new List<ProductDetails>
            {
                //new ProblemDetails{ProductId   },
                new ProductDetails{ ProductId = 1, ProductName = "Desktop", Description = "DellDesktop" },
                new ProductDetails{ ProductId = 2, ProductName = "NewDesktop", Description = "phpDesktop"},
                new ProductDetails{ ProductId = 3, ProductName = "OldDesktop", Description = "LenovoDesktop"},
                new ProductDetails{ ProductId = 4, ProductName = "Desktop", Description = "DellDesktop" },
                new ProductDetails{ ProductId = 5, ProductName = "NewDesktop", Description = "phpDesktop"},
                new ProductDetails{ ProductId = 6, ProductName = "OldDesktop", Description = "LenovoDesktop"},
                new ProductDetails{ ProductId = 7, ProductName = "GoodDeskTop", Description = "test7"},
                new ProductDetails{ ProductId = 8, ProductName = "NewLookDesktop", Description = "Test8"}
            };
            return Json(products, convert);
        }

        
    }
}
