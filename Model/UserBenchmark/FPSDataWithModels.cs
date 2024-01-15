namespace PCConfig.Model.UserBenchmark
{
    public class FPSDataWithModels
    {
        public int Id { get; set; }

        public double FPS { get; set; }

        public int Samples { get; set; }

        public Resolution Resolution { get; set; }

        public GameSettings GameSettings { get; set; }

        public string CPUModel { get; set; }

        public string GPUModel { get; set; }
    }
}
