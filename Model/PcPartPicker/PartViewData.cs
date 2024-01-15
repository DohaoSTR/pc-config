namespace PCConfig.Model.PcPartPicker
{
    public abstract class PartViewData
    {
        public abstract IEnumerable<ShortSpecification> GetSpecificationList();
    }
}
