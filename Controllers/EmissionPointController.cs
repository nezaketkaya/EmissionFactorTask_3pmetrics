using EmissionFactorTask_3pmetrics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmissionFactorTask_3pmetrics.Controllers
{
    public class EmissionPointController : Controller
    {
            private readonly AppDbContext _dbContext;
            public EmissionPointController(AppDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult CheckPoint(string pName)
        {
            var existingPoint = _dbContext.EmissionPoint.Any(ep => ep.pointName == pName);

            return Ok(existingPoint);
        }



        [HttpGet]
        public IActionResult AddEP()
        {
            var emissionPoints = _dbContext.EmissionPoint.ToList();
            ViewBag.EPoints = emissionPoints;

            return View();
        }



        [HttpPost]
        public IActionResult AddEP(EmissionPoints newPoint)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    newPoint.creationDate = DateTime.Now;
                    _dbContext.EmissionPoint.Add(newPoint);

                    _dbContext.SaveChanges();

                    TempData["SuccessMessage"] = "New point has been successfully saved.";

                    return RedirectToAction("AddEP");
                }
                else
                {
                    TempData["ErrorMessage"] = "Point could not be saved. Please check your inputs.";

                    return View(newPoint);
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }


        [HttpPost]
        public IActionResult Delete(EmissionPoints points)
        {
            var item =  _dbContext.EmissionPoint.Find(points.id);
            if (item != null)
            {
                _dbContext.EmissionPoint.Remove(item);
                _dbContext.SaveChanges();

                return RedirectToAction("AddEP");
            }

            return RedirectToAction("AddEP");
        }

    }
}
