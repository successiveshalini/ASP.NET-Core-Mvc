
using Microsoft.AspNetCore.Mvc;
using MyMobile.Data;
using MyMobile.Models;

namespace MyMobile.Controllers
{
    public class MobileController : Controller
    {
        private readonly MobileDBContext mob;
       

        public MobileController(MobileDBContext mob) 
        {
            this.mob = mob;



        }
        public IActionResult Index()
        {
            var result = mob.MobileDBContexts.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Create(MobileDetails Model)
        {
            if(ModelState.IsValid) 
            {
                var mobile = new MobileDetails()
                {
                    MobName = Model.MobName,
                    MobModel = Model.MobModel,
                    MobPrice = Model.MobPrice
                };
                mob.MobileDBContexts.Add(Model);
                mob.SaveChanges();
                TempData["message"] = "Mobile Added successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Empty field can't submit";
                return View(Model);  
            }
        }
        
        public  IActionResult Delete(int id)
        {
            var Muk = mob.MobileDBContexts.SingleOrDefault(e => e.MobId == id);
            mob.MobileDBContexts.Remove(Muk);
            mob.SaveChanges();
            TempData["message"] = "Mobile deleted successfully";
            return RedirectToAction("Index");
            
        }

        public  IActionResult Edit(int id)
        {
            var Muk = mob.MobileDBContexts.SingleOrDefault(e => e.MobId == id);
            var mobile = new MobileDetails()
            {
                MobId=Muk.MobId,
                MobName = Muk.MobName,
                MobModel = Muk.MobModel,
                MobPrice = Muk.MobPrice
            };
            return View(mobile);
        }
        [HttpPost]
        public IActionResult Edit(MobileDetails Model)
        {
            
            
                var mobile = new MobileDetails()
                {
                    MobId = Model.MobId,
                    MobName = Model.MobName,
                    MobModel = Model.MobModel,
                    MobPrice = Model.MobPrice
                };
                mob.MobileDBContexts.Update(mobile);
                mob.SaveChanges();
                TempData["message"] = "Mobile Updated successfully";
            TempData["error"] = "Records Updated";
            return RedirectToAction("Index");
                
        }
            
                
                
            
    }
    
}
