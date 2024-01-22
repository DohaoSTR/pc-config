namespace PCConfig.Model.PcPartPicker
{
    public enum LongSpecificationType
    {
        Standard,
        Category
    }

    public class LongSpecification : ShortSpecification
    {
        public LongSpecificationType LongSpecificationType { get; set; } = LongSpecificationType.Standard;
    }
}
