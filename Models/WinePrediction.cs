namespace WineRecommendationMVC.Models
{
    public class WinePrediction
    {
        public int Id { get; set; }

        public string WineType { get; set; } = string.Empty;

        public float PredictedQuality { get; set; }

        public string Recommendation { get; set; } = string.Empty;

        public int WineSampleId { get; set; }
        public WineSample WineSample { get; set; } = null!;
        public WineNote? WineNote { get; set; } 

    }
}
