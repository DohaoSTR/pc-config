using PCConfig.Model.Contexts;
using PCConfig.Model.Converters;
using PCConfig.Model.PcPartPicker.Entities.CPU;

namespace PCConfig.Model.PcPartPicker.LongResult
{
    public class CPULongResult : LongPartViewData
    {
        public int? CoreCount { get; set; }
        public double? PerformanceCoreClock { get; set; }
        public double? PerformanceBoostClock { get; set; }
        public string? Socket { get; set; }
        public string? IntegratedGraphics { get; set; }
        public string? Microarchitecture { get; set; }
        public string? CoreFamily { get; set; }
        public int? Lithography { get; set; }
        public string? SimultaneousMultithreading { get; set; }

        public int? TDP { get; set; }
        public string? IncludesCooler { get; set; }
        public string? Series { get; set; }
        public int? MaximumSupportedMemory { get; set; }
        public string? ECCSupport { get; set; }
        public string? Packaging { get; set; }
        public string? Model { get; set; }

        public double? EffectiveSpeed { get; set; }
        public double? AvgMemoryLatency { get; set; }
        public double? AvgSingleCoreSpeed { get; set; }
        public double? AvgDualCoreSpeed { get; set; }
        public double? AvgQuadCoreSpeed { get; set; }
        public double? AvgOctaCoreSpeed { get; set; }
        public double? AvgMultiCoreSpeed { get; set; }
        public double? OcMemoryCoreSpeed { get; set; }
        public double? OcSingleCoreSpeed { get; set; }
        public double? OcDualCoreSpeed { get; set; }
        public double? OcQuadCoreSpeed { get; set; }
        public double? OcOctaCoreSpeed { get; set; }
        public double? OcMultiCoreSpeed { get; set; }

        public int? GamingPercentage { get; set; }
        public int? DesktopPercentage { get; set; }
        public int? WorkstationPercentage { get; set; }

        public string? CacheIds { get; set; }

        public override IEnumerable<LongSpecification> GetSpecificationList()
        {
            IntegratedGraphicsConverter integratedGraphicsConverter = new IntegratedGraphicsConverter();
            YesNoConverter yesNoConverter = new YesNoConverter();

            var specifications = new List<LongSpecification>
            {
                new LongSpecification { Name = "Характеристики комплектующей", LongSpecificationType = LongSpecificationType.Category },

                new LongSpecification { Name = "Количество ядер", Value = CoreCount },
                new LongSpecification { Name = "Базовая частота процессора", Value = PerformanceCoreClock, Measure = "ГГц" },
                new LongSpecification { Name = "Максимальная частота в турбо режиме", Value = PerformanceBoostClock, Measure = "ГГц" },
                new LongSpecification { Name = "Тепловыделение (TDP)", Value = TDP, Measure = "Вт" },
                new LongSpecification { Name = "Система охлаждения в комплекте", Value = yesNoConverter.Convert(IncludesCooler, null, null, null).ToString() },
                new LongSpecification { Name = "Интегрированное графическое ядро", Value = integratedGraphicsConverter.Convert(IntegratedGraphics, null, null, null).ToString() },
                new LongSpecification { Name = "Сокет", Value = Socket.ToString() },
                new LongSpecification { Name = "Микроархитектура", Value = Microarchitecture },
                new LongSpecification { Name = "Семейство ядер", Value = CoreFamily },
                new LongSpecification { Name = "Техпроцесс", Value = Lithography, Measure = "нм" },
                new LongSpecification { Name = "Многозадачность", Value = SimultaneousMultithreading },
                new LongSpecification { Name = "Серия", Value = Series },
                new LongSpecification { Name = "Максимальный объем памяти", Value = MaximumSupportedMemory, Measure = "ГБ" },
                new LongSpecification { Name = "Поддержка ECC", Value = ECCSupport },
                new LongSpecification { Name = "Упаковка", Value = Packaging },
                new LongSpecification { Name = "Модель", Value = Model },
            };

            PCPartPickerContext context = new PCPartPickerContext();

            if (CacheIds != null)
            {
                List<string> ids = CacheIds.Split(",").ToList();
                int index = 1;
                foreach (string id in ids)
                {
                    CPUCache entity = context.CPUCaches.Where(x => x.Id == Convert.ToInt32(id)).First();

                    List<LongSpecification> specification = new List<LongSpecification>
                    {
                        new LongSpecification { Name = $"Производительность кэша №{index}", LongSpecificationType = LongSpecificationType.Category },

                        new LongSpecification { Name = "Количество строк L1 инструкций", Value = entity.CountLinesL1Instruction, Measure = "шт." },
                        new LongSpecification { Name = "Объем L1 инструкций", Value = entity.CapacityL1Instruction, Measure = "байт" },
                        new LongSpecification { Name = "Количество строк L1 данных", Value = entity.CountLinesL1Data, Measure = "шт." },
                        new LongSpecification { Name = "Объем L1 данных", Value = entity.CapacityL1Data, Measure = "байт" },
                        new LongSpecification { Name = "Количество строк L2", Value = entity.CountLinesL2, Measure = "шт." },
                        new LongSpecification { Name = "Объем L2", Value = entity.CapacityL2, Measure = "байт" },
                        new LongSpecification { Name = "Количество строк L3", Value = entity.CountLinesL3, Measure = "шт." },
                        new LongSpecification { Name = "Объем L3", Value = entity.CapacityL3, Measure = "байт" },
                    };

                    specifications.AddRange(specification);
                    index++;
                }
            }

            List<LongSpecification> metrics = new()
            {
                new LongSpecification { Name = "Общие метрики", LongSpecificationType = LongSpecificationType.Category },
                new LongSpecification { Name = "Игровая метрика", Value = GamingPercentage, Measure = "%" },
                new LongSpecification { Name = "Стационарная метрика", Value = DesktopPercentage, Measure = "%" },
                new LongSpecification { Name = "Рабочая метрика", Value = WorkstationPercentage, Measure = "%" }
            };
            AddMetricsCategory(specifications, metrics);

            List<LongSpecification> perfomanceMetrics = new()
            {
                new LongSpecification { Name = "Метрики производительности", LongSpecificationType = LongSpecificationType.Category },
                new LongSpecification { Name = "Эффективная скорость", Value = EffectiveSpeed, Measure = "Pts" },
                new LongSpecification { Name = "Средняя задержка памяти", Value = AvgMemoryLatency, Measure = "Pts" },
                new LongSpecification { Name = "Средняя скорость одного ядра", Value = AvgSingleCoreSpeed, Measure = "Pts" },
                new LongSpecification { Name = "Средняя скорость двух ядер", Value = AvgDualCoreSpeed, Measure = "Pts" },
                new LongSpecification { Name = "Средняя скорость четырех ядер", Value = AvgQuadCoreSpeed, Measure = "Pts" },
                new LongSpecification { Name = "Средняя скорость восьми ядер", Value = AvgOctaCoreSpeed, Measure = "Pts" },
                new LongSpecification { Name = "Средняя многозадачность", Value = AvgMultiCoreSpeed, Measure = "Pts" },
                new LongSpecification { Name = "OC Память", Value = OcMemoryCoreSpeed, Measure = "Pts" },
                new LongSpecification { Name = "OC Одно ядро", Value = OcSingleCoreSpeed, Measure = "Pts" },
                new LongSpecification { Name = "OC Двух ядер", Value = OcDualCoreSpeed, Measure = "Pts" },
                new LongSpecification { Name = "OC Четырех ядер", Value = OcQuadCoreSpeed, Measure = "Pts" },
                new LongSpecification { Name = "OC Восьми ядер", Value = OcOctaCoreSpeed, Measure = "Pts" },
                new LongSpecification { Name = "OC Многозадачность", Value = OcMultiCoreSpeed, Measure = "Pts" }
            };
            AddMetricsCategory(specifications, perfomanceMetrics);

            return specifications;
        }
    }
}
