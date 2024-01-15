namespace PCConfig.Model.UserBenchmark
{
    public enum GameSettings
    {
        [DatabaseValue("Low")]
        Low,

        [DatabaseValue("Med")]
        Med,

        [DatabaseValue("High")]
        High,

        [DatabaseValue("Max")]
        Max,

        [DatabaseValue("None")]
        None
    }
}
