namespace PCConfig.Model.PcPartPicker
{
    public abstract class PartViewData
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Manufacturer { get; set; }

        public string? Link { get; set; }

        public string? ImageLinks { get; set; }

        public abstract IEnumerable<ShortSpecification> GetSpecificationList();
    }
}
