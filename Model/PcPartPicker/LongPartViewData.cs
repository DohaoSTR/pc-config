namespace PCConfig.Model.PcPartPicker
{
    public abstract class LongPartViewData
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Manufacturer { get; set; }

        public string? Link { get; set; }

        public string? ImageLinks { get; set; }

        public string? PartNumbers { get; set; }

        public string? DNSUid { get; set; }

        public int? CitilinkId { get; set; }

        public abstract IEnumerable<LongSpecification> GetSpecificationList();

        public static void AddMetricsCategory(List<LongSpecification> specifications, List<LongSpecification> metrics)
        {
            bool allValuesNull = metrics.All(spec => spec.Value is null or (object)0 or (object)"");

            if (allValuesNull == false)
            {
                specifications.AddRange(metrics);
            }
        }
    }
}
