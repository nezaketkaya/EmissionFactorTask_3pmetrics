using EmissionFactorTask_3pmetrics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmissionFactorTask_3pmetrics.Controllers
{
    public class EmissionFactorController : Controller
    {
        private readonly AppDbContext _dbContext;
        public EmissionFactorController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddEF()
        {
            var emissionTitles = new List<string> { "Diesell Litre", "Diesell Ton"};
            ViewBag.EmissionTitles = new SelectList(emissionTitles);


            var emissionFactors = _dbContext.EmissionFactor.ToList();
            ViewBag.EF = emissionFactors;

            return View();
        }



        [HttpPost]
        public IActionResult AddEF(EmissionFactors newEF)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    newEF.creationDate = DateTime.Now;
                    _dbContext.EmissionFactor.Add(newEF);

                    _dbContext.SaveChanges();

                    TempData["SuccessMessage"] = "New ef has been successfully saved.";

                    return RedirectToAction("AddEF");
                }
                else
                {
                    TempData["ErrorMessage"] = "Ef could not be saved. Please check your inputs.";

                    return View(newEF);
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }


        [HttpPost]
        public IActionResult Delete(EmissionFactors ef)
        {
            var item = _dbContext.EmissionFactor.Find(ef.id);
            if (item != null)
            {
                _dbContext.EmissionFactor.Remove(item);
                _dbContext.SaveChanges();

                return RedirectToAction("AddEF");
            }

            return RedirectToAction("AddEF");
        }





    }
}