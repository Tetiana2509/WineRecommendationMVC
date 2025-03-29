using Microsoft.AspNetCore.Mvc;
using WineRecommendationMVC.Data;
using WineRecommendationMVC.Models;

namespace WineRecommendationMVC.Controllers
{
    public class WhiteWineController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public WhiteWineController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Home/WhiteWineForm2.cshtml");
        }

        [HttpPost]
        public IActionResult Recommend(WhiteWineModel.ModelInput input)
        {
            var result = WhiteWineModel.Predict(input);

            float predictedQuality = result.Score;

            string recommendation;
            if (predictedQuality >= 8)
            {
                recommendation = "Рекомендуємо обрати це вино. Це вино високої якості!";
            }
            else if (predictedQuality >= 5)
            {
                recommendation = "Це вино має середню якість. Може підійти для щоденного вживання.";
            }
            else
            {
                recommendation = "Не рекомендуємо обирати це вино. Воно має низьку якість.";
            }

            var sample = new WineSample
            {
                FixedAcidity = input.Fixed_acidity,
                VolatileAcidity = input.Volatile_acidity,
                CitricAcid = input.Citric_acid,
                ResidualSugar = input.Residual_sugar,
                Chlorides = input.Chlorides,
                FreeSulfurDioxide = input.Free_sulfur_dioxide,
                TotalSulfurDioxide = input.Total_sulfur_dioxide,
                Density = input.Density,
                PH = input.PH,
                Sulphates = input.Sulphates,
                Alcohol = input.Alcohol
            };
            _dbContext.WineSamples.Add(sample);
            _dbContext.SaveChanges();

            var prediction = new WinePrediction
            {
                WineType = "White",
                PredictedQuality = predictedQuality,
                Recommendation = recommendation,
                WineSampleId = sample.Id
            };
            _dbContext.WinePredictions.Add(prediction);
            _dbContext.SaveChanges();

            ViewBag.PredictedQuality = predictedQuality;
            ViewBag.Recommendation = recommendation;

            return View("~/Views/Home/Result3.cshtml", prediction);
        }
    }
}