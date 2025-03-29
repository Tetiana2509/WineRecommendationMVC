using Microsoft.AspNetCore.Mvc;
using WineRecommendationMVC.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WineRecommendationMVC.Controllers
{
    public class HistoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public HistoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(string sortBy = "date")
        {
            var historyQuery = _dbContext.WinePredictions
                .Include(p => p.WineSample)
                .Include(p => p.WineNote)
                .AsQueryable();

            switch (sortBy.ToLower())
            {
                case "quality":
                    historyQuery = historyQuery.OrderByDescending(p => p.PredictedQuality);
                    break;
                case "alcohol":
                    historyQuery = historyQuery.OrderByDescending(p => p.WineSample.Alcohol);
                    break;
                default:
                    historyQuery = historyQuery.OrderByDescending(p => p.Id);
                    break;
            }

            var history = historyQuery.ToList();
            return View(history);

        }
    }
}
