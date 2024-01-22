namespace PCConfig.Model.PcPartPicker.ShortViewData
{
    public class GPUShortResult : PartViewData
    {
        public string? MemoryType { get; set; }

        public double? Memory { get; set; }

        public int? CoreClock { get; set; }


        public int? GamingPercentage { get; set; }

        public int? DesktopPercentage { get; set; }

        public int? WorkstationPercentage { get; set; }


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
