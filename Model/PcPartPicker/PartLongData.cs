using PCConfig.Model.PcPartPicker.Entities;
using PCConfig.Model.PcPartPicker.PriceResults;

namespace PCConfig.Model.PcPartPicker
{
    public class PartLongData
    {
        public Part? Part { get; set; }

        public LongPartViewData? PartViewData { get; set; }

        public IEnumerable<ShortSpecification>? Specifications { get; set; }

        public IEnumerable<string>? ImagesUrls { get; set; }

        public string? DNSLink { get; set; }

        public string? CitilinkLink { get; set; }

        public IEnumerable<string>? PartNumbers { get; set; }

        public IEnumerable<DNSAvailableResult> DNSAvailables { get; set; }

        public DNSPriceResult DNSPrice { get; set; }

        public IEnumerable<CitilinkAvailableResult> CitilinkAvailables { get; set; }

        public CitilinkPriceResult CitilinkPrice { get; set; }
    }
}
