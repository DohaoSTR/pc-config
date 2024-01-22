using PCConfig.Model.Converters;

namespace PCConfig.Model.PcPartPicker.LongResult
{
    public class HybridStorageLongResult : LongPartViewData
    {
        public double? Capacity { get; set; }
        public string? CapacityMeasure { get; set; }
        public double? Price { get; set; }
        public string? PriceMeasure { get; set; }
        public double? Cache { get; set; }
        public string? CacheMeasure { get; set; }
        public double? HybridSSDCache { get; set; }
        public string? HybridSSDCacheMeasure { get; set; }
        public string? FormFactor { get; set; }
        public string? Interface { get; set; }
        public string? Model { get; set; }
        public string? PowerLossProtection { get; set; }

        public int? GamingPercentage { get; set; }
        public int? DesktopPercentage { get; set; }
        public int? WorkstationPercentage { get; set; }

        public override IEnumerable<LongSpecification> GetSpecificationList()
        {
            MeasureConverter measureConverter = new MeasureConverter();
            Tuple<string, string?> tuple = HelpFunctions.ParseInterface(Interface);

            var specifications = new List<LongSpecification>
            {
                new LongSpecification { Name = "Характеристики комплектующей", LongSpecificationType = LongSpecificationType.Category },
                new LongSpecification
                {
                    Name = "Интерфейс",
                    Value = tuple.Item1
                },
                new LongSpecification
                {
                    Name = "Пропускная способность интерфейса",
                    Value = tuple.Item2,
                    Measure = "Гбит/с"
                },
                new LongSpecification
                {
                    Name = "Объем диска",
                    Value = Capacity,
                    Measure = measureConverter.Convert(CapacityMeasure, null, null, null).ToString()
                },
                new LongSpecification
                {
                    Name = "Объем кэш-памяти",
                    Value = Cache,
                    Measure = measureConverter.Convert(CacheMeasure, null, null, null).ToString()
                },
                new LongSpecification
                {
                    Name = "Объем SSD кэш-памяти",
                    Value = HybridSSDCache,
                    Measure = measureConverter.Convert(HybridSSDCacheMeasure, null, null, null).ToString()
                },
                new LongSpecification { Name = "Форм-фактор", Value = FormFactor },
                new LongSpecification { Name = "Модель", Value = Model },
                new LongSpecification { Name = "Защита от потери электропитания", Value = PowerLossProtection },
            };

            List<LongSpecification> metrics = new()
            {
                new LongSpecification { Name = "Общие метрики", LongSpecificationType = LongSpecificationType.Category },
                new LongSpecification { Name = "Игровая метрика", Value = GamingPercentage, Measure = "%" },
                new LongSpecification { Name = "Стационарная метрика", Value = DesktopPercentage, Measure = "%" },
                new LongSpecification { Name = "Рабочая метрика", Value = WorkstationPercentage, Measure = "%" }
            };
            AddMetricsCategory(specifications, metrics);

            return specifications;
        }
    }
}
