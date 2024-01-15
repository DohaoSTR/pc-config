namespace PCConfig.Model.UserBenchmark
{
    public enum Resolution
    {
        [DatabaseValue("720p")]
        HD,

        [DatabaseValue("1080p")]
        FullHD,

        [DatabaseValue("1440p")]
        QHD,

        [DatabaseValue("4K")]
        K4,

        [DatabaseValue("None")]
        None
    }
}
