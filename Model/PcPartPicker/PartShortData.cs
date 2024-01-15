using PCConfig.Model.PcPartPicker.Entities;

namespace PCConfig.Model.PcPartPicker
{
    public class PartShortData
    {
        public Part Part { get; set; }

        public PartViewData PartViewData { get; set; }

        public IEnumerable<ShortSpecification> Specifications { get; set; }

        public IEnumerable<string> ImagesUrls { get; set; }
    }
}
