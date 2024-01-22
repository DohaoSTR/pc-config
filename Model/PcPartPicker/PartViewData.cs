namespace PCConfig.Model.PcPartPicker
{
    public abstract class PartViewData
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Manufacturer { get; set; }

        public string? Link { get; set; }

        public string? PartType { get; set; }

        public string? ImageLinks { get; set; }


        public decimal? CitilinkPrice { get; set; }

        public DateTime? CitilinkPriceDateTime { get; set; }

        public bool? CitilinkIsAvailable { get; set; }

        public DateTime? CitilinkAvailDateTime { get; set; }

        public string? CitilinkLink { get; set; }


        public decimal? DNSPrice { get; set; }

        public DateTime? DNSPriceDateTime { get; set; }

        public string? DNSStatus { get; set; }

        public string? DNSDeilveryInfo { get; set; }

        public DateTime? DNSAvailDateTime { get; set; }

        public string? DNSLink { get; set; }

        public abstract IEnumerable<ShortSpecification> GetSpecificationList();
    }
}
