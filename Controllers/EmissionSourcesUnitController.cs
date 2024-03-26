using EmissionFactorTask_3pmetrics.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmissionFactorTask_3pmetrics.Controllers
{
    public class EmissionSourcesUnitController : Controller
    {
        private readonly AppDbContext _dbContext;
        public EmissionSourcesUnitController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public IActionResult AddESU()
        {
            var emissionSourcesUnits = _dbContext.EmissionSourcesUnit.ToList();
            ViewBag.ESU = emissionSourcesUnits;

            return View();
        }



        [HttpPost]
        public IActionResult AddESU(EmissionSourcesUnits newSourceUnit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    newSourceUnit.creationDate = DateTime.Now;
                    _dbContext.EmissionSourcesUnit.Add(newSourceUnit);

                    _dbContext.SaveChanges();

                    TempData["SuccessMessage"] = "New source unit has been successfully saved.";

                    return RedirectToAction("AddESU");
                }
                else
                {
                    TempData["ErrorMessage"] = "Source unit could not be saved. Please check your inputs.";

                    return View(newSourceUnit);
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Delete(EmissionSourcesUnits sourcesUnit)
        {
            var item = _dbContext.EmissionSourcesUnit.Find(sourcesUnit.id);
            if (item != null)
            {
                _dbContext.EmissionSourcesUnit.Remove(item);
                _dbContext.SaveChanges();

                return RedirectToAction("AddESU");
            }

            return RedirectToAction("AddESU");
        }

    }
}
