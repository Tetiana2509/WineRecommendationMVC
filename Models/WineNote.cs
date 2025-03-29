namespace WineRecommendationMVC.Models
{
    public class WineNote
    {
        public int Id { get; set; }
        public string Comment { get; set; } = string.Empty;

        public int WinePredictionId { get; set; }
        public WinePrediction WinePrediction { get; set; } = null!;
    }
}
