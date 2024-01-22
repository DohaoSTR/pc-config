using PCConfig.Model.Converters;

namespace PCConfig.Model.PcPartPicker.ShortViewData
{
    public class RAMShortResult : PartViewData
    {
        public int? MemorySpeed { get; set; }

        public string? MemoryType { get; set; }

        public int? ModulesCount { get; set; }

        public int? ModulesMemory { get; set; }

        public string? ModulesMemoryMeasure { get; set; }

        public int? Cas { get; set; }

        public int? Trcd { get; set; }

        public int? Trp { get; set; }

        public int? Tras { get; set; }


        public int? GamingPercentage { get; set; }

        public int? DesktopPercentage { get; set; }

        public int? WorkstationPercentage { get; set; }


        public override IEnumerable<ShortSpecification> GetSpecificationList()
        {
            MeasureConverter gbConverter = new MeasureConverter();

            var values = new List<ShortSpecification>
            {
                new ShortSpecification
                {
                    Name = "Тактовая частота",
                    Value = MemorySpeed,
                    Measure = "МГц"
                },
                new ShortSpecification
                {
                    Name = "Тип памяти",
                    Value = MemoryType,
                },
                new ShortSpecification
                {
                    Name = "Количество модулей в комплекте",
                    Value = ModulesCount
                },
                new ShortSpecification
                {
                    Name = "Объем одного модуля памяти",
                    Value = ModulesMemory,
                    Measure = gbConverter.Convert(ModulesMemoryMeasure, null, null, null).ToString()
                },
                new ShortSpecification
                {
                    Name = "Тайминги",
                    Value = Cas.ToString() + "-" + Trcd.ToString() + "-" + Trp.ToString() + "-" + Tras.ToString()
                },
            };

            return values;
        }
    }
}
