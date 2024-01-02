using Microsoft.AspNetCore.Mvc;
using MyCup.Data;
using MyCup.Models;

namespace MyCup.Controllers
{
    public class CupController : Controller
    {
        private readonly CupDBContext context;

        public int IdCup { get;  set; }

        public CupController(CupDBContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.CupDetails.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult Create(CupDetails model)
        {
            if (ModelState.IsValid)
            {
                var Result = new CupDetails()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    Company = model.Company,

                };
                context.CupDetails.Add(Result);
                context.SaveChanges();
                return RedirectToAction("Index");



            }
            else
            {
                return View(model);
            }


        }
        [HttpGet]
        
        public IActionResult Edit(int id)
        {
            var result = context.CupDetails.SingleOrDefault(e => e.IdCup == id);
            var r = new CupDetails()
            {
                IdCup = result.IdCup,
                Name = result.Name,
                Description = result.Description,
                Price = result.Price,
                Company = result.Company, 
            };
            return View(r);

           
        }
        [HttpPost]
        public IActionResult Edit(CupDetails Model)
        {
            var result = context.CupDetails.SingleOrDefault(e => e.IdCup == IdCup);
            var r = new CupDetails()
            {
                IdCup = Model.IdCup,
                Name = Model.Name,
                Description = Model.Description,
                Price = Model.Price,
                Company = Model.Company,
            };

            context.CupDetails.Update(r);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(int Id)
        {
            var result = context.CupDetails.SingleOrDefault(e => e.IdCup == Id);
            context.CupDetails.Remove(result);
            context.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}
