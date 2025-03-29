using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineRecommendationMVC.Data;

namespace WineRecommendationMVC.Controllers
{
    public class CompareController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CompareController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Form()
        {
            var predictions = _db.WinePredictions
                .Include(p => p.WineSample)
                .OrderByDescending(p => p.Id)
                .ToList();

            return View(predictions);
        }

        [HttpPost]
        public IActionResult Result(int wine1, int wine2)
        {
            var p1 = _db.WinePredictions.Include(p => p.WineSample).FirstOrDefault(p => p.Id == wine1);
            var p2 = _db.WinePredictions.Include(p => p.WineSample).FirstOrDefault(p => p.Id == wine2);

            if (p1 == null || p2 == null)
                return NotFound("Одна з вибраних рекомендацій не знайдена");

            var model = (p1, p2);
            return View(model);
        }
    }
}
