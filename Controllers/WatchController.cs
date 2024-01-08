using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyWatch.Data;
using MyWatch.Models;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace MyWatch.Controllers
{
    public class WatchController : Controller
    {
        private readonly WatchDBContext wat;

        public WatchController(WatchDBContext wat)
        {
            this.wat = wat;
        }
        public IActionResult Index()
        {
            var result = wat.WatchDBContexts.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(WatchDetails Model)
        {
            if (ModelState.IsValid)
            {
                var watch = new WatchDetails
                {
                    WatchName = Model.WatchName,
                    WatchModel = Model.WatchModel,
                    WatchPrice = Model.WatchPrice,
                    WatchColor = Model.WatchColor,
                };
                wat.WatchDBContexts.Add(Model);
                wat.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                TempData["error"] = "Empty field can't submit";
                return View(Model);
            }
            


        }
       
        public IActionResult Edit(int id)
        {
            var Abc = wat.WatchDBContexts.SingleOrDefault(e => e.WatchId == id);
            var Watch = new WatchDetails()
            {
               // WatchId =    Abc.WatchId,  
                WatchName =    Abc.WatchName,  
                WatchModel =  Abc.WatchModel,    
                WatchPrice = Abc.WatchPrice,
                WatchColor = Abc.WatchColor,    
                
            };
            return View(Watch);

        }
        [HttpPost]
        public IActionResult Edit(WatchDetails Model)
        {


            var watch = new WatchDetails()
            {
                //WatchId = Model.WatchId,
                WatchName = Model.WatchName,
                WatchModel = Model.WatchModel,
                WatchPrice = Model.WatchPrice,
                WatchColor = Model.WatchColor,  

            };
            wat.WatchDBContexts.Update(watch);
            wat.SaveChanges();
            TempData["error"] = "Records Updated";
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            var obj = wat.WatchDBContexts.SingleOrDefault(e => e.WatchId == id);
            wat.WatchDBContexts.Remove(obj);
            wat.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}




