namespace PCConfig.Model.PcPartPicker.ShortViewData
{
    public class GPUShortViewData : PartViewData
    {
        public string? MemoryType { get; set; }

        public double? Memory { get; set; }

        public int? CoreClock { get; set; }

        public override IEnumerable<ShortSpecification> GetSpecificationList()
        {
            var values = new List<ShortSpecification>
            {
                new ShortSpecification { Name = "Тип памяти", Value = MemoryType },
                new ShortSpecification { Name = "Базовая частота памяти", Value = Memory, Measure = "МГц" },
                new ShortSpecification { Name = "Базовая частота работы видеочипа", Value = CoreClock, Measure = "МГц" },
            };

            return values;
        }
    }
}
