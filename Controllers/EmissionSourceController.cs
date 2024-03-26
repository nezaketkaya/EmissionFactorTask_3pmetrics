using EmissionFactorTask_3pmetrics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmissionFactorTask_3pmetrics.Controllers
{
    public class EmissionSourceController : Controller
    {
        private readonly AppDbContext _dbContext;
        public EmissionSourceController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddES()
        {
            var emissionSources = _dbContext.EmissionSource.ToList();
            ViewBag.ESources = emissionSources;

            return View();
        }



        [HttpPost]
        public IActionResult AddES(EmissionSources newSource)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    newSource.creationDate = DateTime.Now;
                    _dbContext.EmissionSource.Add(newSource);

                    _dbContext.SaveChanges();

                    TempData["SuccessMessage"] = "New source has been successfully saved.";

                    return RedirectToAction("AddES");
                }
                else
                {
                    TempData["ErrorMessage"] = "Source could not be saved. Please check your inputs.";

                    return View(newSource);
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Delete(EmissionSources sources)
        {
            var item = _dbContext.EmissionSource.Find(sources.id);
            if (item != null)
            {
                _dbContext.EmissionSource.Remove(item);
                _dbContext.SaveChanges();

                return RedirectToAction("AddES");
            }

            return RedirectToAction("AddES");
        }

    }
}
