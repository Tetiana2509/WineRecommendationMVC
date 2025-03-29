namespace WineRecommendationMVC.Models
{
    public class WineSample
    {
        public int Id { get; set; }

        public float FixedAcidity { get; set; }
        public float VolatileAcidity { get; set; }
        public float CitricAcid { get; set; }
        public float ResidualSugar { get; set; }
        public float Chlorides { get; set; }
        public float FreeSulfurDioxide { get; set; }
        public float TotalSulfurDioxide { get; set; }
        public float Density { get; set; }
        public float PH { get; set; }
        public float Sulphates { get; set; }
        public float Alcohol { get; set; }

        public WinePrediction? WinePrediction { get; set; }
    }
}
