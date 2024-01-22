using PCConfig.Model.Converters;

namespace PCConfig.Model.PcPartPicker.LongResult
{
    public class RAMLongResult : LongPartViewData
    {
        public int? MemorySpeed { get; set; }
        public string? MemoryType { get; set; }
        public int? PinCount { get; set; }
        public string? MemoryFormFactor { get; set; }
        public int? ModulesCount { get; set; }
        public int? ModulesMemory { get; set; }
        public string? ModulesMemoryMeasure { get; set; }
        public double? FirstWordLatency { get; set; }
        public double? Voltage { get; set; }
        public int? Cas { get; set; }
        public int? Trcd { get; set; }
        public int? Trp { get; set; }
        public int? Tras { get; set; }

        public string? Currency { get; set; }
        public double? PriceGB { get; set; }
        public string? Color { get; set; }
        public string? RegisterMemory { get; set; }
        public string? ECC { get; set; }
        public string? HeatSpreader { get; set; }
        public string? Model { get; set; }

        public double? EffectiveSpeed { get; set; }
        public double? Avg16CoreReadBench { get; set; }
        public double? Avg16CoreWriteBench { get; set; }
        public double? Avg16CoreMixedIoBench { get; set; }
        public double? SixteenCoreReadBench { get; set; }
        public double? SixteenCoreWriteBench { get; set; }
        public double? SixteenCoreMixedIoBench { get; set; }
        public double? Avg1CoreReadBench { get; set; }
        public double? Avg1CoreWriteBench { get; set; }
        public double? Avg1CoreMixedIoBench { get; set; }
        public double? SingleCoreReadBench { get; set; }
        public double? SingleCoreWriteBench { get; set; }
        public double? SingleCoreMixedIoBench { get; set; }

        public int? GamingPercentage { get; set; }
        public int? DesktopPercentage { get; set; }
        public int? WorkstationPercentage { get; set; }

        public override IEnumerable<LongSpecification> GetSpecificationList()
        {
            MeasureConverter gbConverter = new MeasureConverter();

            var specifications = new List<LongSpecification>
            {
                new LongSpecification { Name = "Характеристики комплектующей", LongSpecificationType = LongSpecificationType.Category },
                new LongSpecification
                {
                    Name = "Тактовая частота",
                    Value = MemorySpeed,
                    Measure = "МГц"
                },
                new LongSpecification
                {
                    Name = "Тип памяти",
                    Value = MemoryType,
                },
                new LongSpecification
                {
                    Name = "Количество модулей в комплекте",
                    Value = ModulesCount
                },
                new LongSpecification
                {
                    Name = "Объем одного модуля памяти",
                    Value = ModulesMemory,
                    Measure = gbConverter.Convert(ModulesMemoryMeasure, null, null, null).ToString()
                },
                new LongSpecification
                {
                    Name = "Тайминги",
                    Value = Cas.ToString() + "-" + Trcd.ToString() + "-" + Trp.ToString() + "-" + Tras.ToString()
                },
                new LongSpecification { Name = "Количество пинов", Value = PinCount },
                new LongSpecification { Name = "Форм-фактор памяти", Value = MemoryFormFactor },
                new LongSpecification { Name = "Задержка первого слова", Value = FirstWordLatency, Measure = "нс" },
                new LongSpecification { Name = "Напряжение", Value = Voltage, Measure = "В" },
                new LongSpecification { Name = "Цвет", Value = Color },
                new LongSpecification { Name = "Регистровая память", Value = RegisterMemory },
                new LongSpecification { Name = "ECC (Коррекция ошибок)", Value = ECC },
                new LongSpecification { Name = "Теплораспределитель (Heat Spreader)", Value = HeatSpreader },
                new LongSpecification { Name = "Модель", Value = Model }
            };

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
                new LongSpecification { Name = "Эффективная скорость", Value = EffectiveSpeed, Measure = "Pts" },
                new LongSpecification { Name = "Средняя скорость чтения (16 ядер)", Value = Avg16CoreReadBench, Measure = "Pts" },
                new LongSpecification { Name = "Средняя скорость записи (16 ядер)", Value = Avg16CoreWriteBench, Measure = "Pts" },
                new LongSpecification { Name = "Средняя смешанная скорость I/O (16 ядер)", Value = Avg16CoreMixedIoBench, Measure = "Pts" },
                new LongSpecification { Name = "Скорость чтения (16 ядер)", Value = SixteenCoreReadBench, Measure = "Pts" },
                new LongSpecification { Name = "Скорость записи (16 ядер)", Value = SixteenCoreWriteBench, Measure = "Pts" },
                new LongSpecification { Name = "Смешанная скорость I/O (16 ядер)", Value = SixteenCoreMixedIoBench, Measure = "Pts" },
                new LongSpecification { Name = "Средняя скорость чтения (1 ядро)", Value = Avg1CoreReadBench, Measure = "Pts" },
                new LongSpecification { Name = "Средняя скорость записи (1 ядро)", Value = Avg1CoreWriteBench, Measure = "Pts" },
                new LongSpecification { Name = "Средняя смешанная скорость I/O (1 ядро)", Value = Avg1CoreMixedIoBench, Measure = "Pts" },
                new LongSpecification { Name = "Скорость чтения (1 ядро)", Value = SingleCoreReadBench, Measure = "Pts" },
                new LongSpecification { Name = "Скорость записи (1 ядро)", Value = SingleCoreWriteBench, Measure = "Pts" },
                new LongSpecification { Name = "Смешанная скорость I/O (1 ядро)", Value = SingleCoreMixedIoBench, Measure = "Pts" },
            };
            AddMetricsCategory(specifications, perfomanceMetrics);

            return specifications;
        }
    }
}
