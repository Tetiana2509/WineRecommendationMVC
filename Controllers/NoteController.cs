using Microsoft.AspNetCore.Mvc;
using WineRecommendationMVC.Data;
using WineRecommendationMVC.Models;

namespace WineRecommendationMVC.Controllers
{
    public class NoteController : Controller
    {
        private readonly ApplicationDbContext _db;

        public NoteController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult Add(int predictionId, string comment)
        {
            if (string.IsNullOrWhiteSpace(comment))
                return BadRequest("Коментар не може бути пустим");

            var note = new WineNote
            {
                WinePredictionId = predictionId,
                Comment = comment
            };

            _db.WineNotes.Add(note);
            _db.SaveChanges();

            return Ok("Збережено");
        }
    }
}
