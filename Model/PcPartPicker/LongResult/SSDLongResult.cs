using PCConfig.Model.Converters;

namespace PCConfig.Model.PcPartPicker.LongResult
{
    public class SSDLongResult : LongPartViewData
    {
        public double? Capacity { get; set; }
        public string? CapacityMeasure { get; set; }
        public double? Price { get; set; }
        public string? PriceMeasure { get; set; }
        public double? Cache { get; set; }
        public string? CacheMeasure { get; set; }
        public string? FormFactor { get; set; }
        public string? Interface { get; set; }
        public string? Model { get; set; }
        public string? PowerLossProtection { get; set; }
        public string? NVMe { get; set; }
        public string? SSDNANDFlashType { get; set; }
        public string? SSDController { get; set; }

        public double? EffectiveSpeed { get; set; }
        public double? AvgSequentialReadSpeed { get; set; }
        public double? AvgSequentialWriteSpeed { get; set; }
        public double? Avg4kRandomReadSpeed { get; set; }
        public double? Avg4kRandomWriteSpeed { get; set; }
        public double? AvgSequentialMixedIoSpeed { get; set; }
        public double? Avg4kRandomMixedIoSpeed { get; set; }
        public double? AvgSustainedWriteSpeed { get; set; }
        public double? PeakSequentialReadSpeed { get; set; }
        public double? PeakSequentialWriteSpeed { get; set; }
        public double? Peak4kRandomReadSpeed { get; set; }
        public double? Peak4kRandomWriteSpeed { get; set; }
        public double? PeakSequentialMixedIoSpeed { get; set; }
        public double? Peak4kRandomMixedIoSpeed { get; set; }
        public double? PeakSequentialSustainedWrite60sAverage { get; set; }
        public double? Peak4k64ThreadReadSpeed { get; set; }
        public double? Peak4k64ThreadWriteSpeed { get; set; }
        public double? Peak4k64ThreadMixedIoSpeed { get; set; }
        public double? Avg4k64ThreadReadSpeed { get; set; }
        public double? Avg4k64ThreadWriteSpeed { get; set; }
        public double? Avg4k64ThreadMixedIoSpeed { get; set; }

        public int? GamingPercentage { get; set; }
        public int? DesktopPercentage { get; set; }
        public int? WorkstationPercentage { get; set; }

        public override IEnumerable<LongSpecification> GetSpecificationList()
        {
            MeasureConverter measureConverter = new MeasureConverter();
            Tuple<string, string?> tuple = HelpFunctions.ParseInterface(Interface);

            string? interfaceName = null;
            string? interfaceSpeed = null;
            if (tuple != null)
            {
                interfaceName = tuple.Item1;
                interfaceSpeed = tuple.Item2;
            }

            var specifications = new List<LongSpecification>
            {
                new LongSpecification { Name = "Характеристики комплектующей", LongSpecificationType = LongSpecificationType.Category },
                new LongSpecification
                {
                    Name = "Интерфейс",
                    Value = interfaceName
                },
                new LongSpecification
                {
                    Name = "Пропускная способность интерфейса",
                    Value = interfaceSpeed,
                    Measure = "Гбит/с"
                },
                new LongSpecification
                {
                    Name = "Объем SSD",
                    Value = Capacity,
                    Measure = measureConverter.Convert(CapacityMeasure, null, null, null).ToString()
                },
                new LongSpecification
                {
                    Name = "Объем кэш-памяти",
                    Value = Cache,
                    Measure = measureConverter.Convert(CacheMeasure, null, null, null).ToString()
                },
                new LongSpecification { Name = "Форм-фактор", Value = FormFactor },
                new LongSpecification { Name = "Модель", Value = Model },
                new LongSpecification { Name = "Защита от потери электропитания", Value = PowerLossProtection },
                new LongSpecification { Name = "NVMe", Value = NVMe },
                new LongSpecification { Name = "Тип NAND Flash памяти", Value = SSDNANDFlashType },
                new LongSpecification { Name = "Контроллер SSD", Value = SSDController },
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
                new LongSpecification { Name = "Метрики производительности", LongSpecificationType = LongSpecificationType.Category },
                new LongSpecification { Name = "Эффективная скорость", Value = EffectiveSpeed, Measure = "МБ/с" },
                new LongSpecification { Name = "Средняя скорость последовательного чтения", Value = AvgSequentialReadSpeed, Measure = "МБ/с" },
                new LongSpecification { Name = "Средняя скорость последовательной записи", Value = AvgSequentialWriteSpeed, Measure = "МБ/с" },
                new LongSpecification { Name = "Средняя скорость случайного чтения (4К)", Value = Avg4kRandomReadSpeed, Measure = "МБ/с" },
                new LongSpecification { Name = "Средняя скорость случайной записи (4К)", Value = Avg4kRandomWriteSpeed, Measure = "МБ/с" },
                new LongSpecification { Name = "Средняя смешанная скорость I/O последовательного доступа", Value = AvgSequentialMixedIoSpeed, Measure = "МБ/с" },
                new LongSpecification { Name = "Средняя смешанная скорость I/O случайного доступа (4К)", Value = Avg4kRandomMixedIoSpeed, Measure = "МБ/с" },
                new LongSpecification { Name = "Средняя скорость устойчивой записи", Value = AvgSustainedWriteSpeed, Measure = "МБ/с" },
                new LongSpecification { Name = "Пиковая скорость последовательного чтения", Value = PeakSequentialReadSpeed, Measure = "МБ/с" },
                new LongSpecification { Name = "Пиковая скорость последовательной записи", Value = PeakSequentialWriteSpeed, Measure = "МБ/с" },
                new LongSpecification { Name = "Пиковая скорость случайного чтения (4К)", Value = Peak4kRandomReadSpeed, Measure = "МБ/с" },
                new LongSpecification { Name = "Пиковая скорость случайной записи (4К)", Value = Peak4kRandomWriteSpeed, Measure = "МБ/с" },
                new LongSpecification { Name = "Пиковая смешанная скорость I/O последовательного доступа", Value = PeakSequentialMixedIoSpeed, Measure = "МБ/с" },
                new LongSpecification { Name = "Пиковая смешанная скорость I/O случайного доступа (4К)", Value = Peak4kRandomMixedIoSpeed, Measure = "МБ/с" },
                new LongSpecification { Name = "Пиковая скорость устойчивой записи (60с среднее)", Value = PeakSequentialSustainedWrite60sAverage, Measure = "МБ/с" },
                new LongSpecification { Name = "Пиковая скорость чтения (4К, 64 потока)", Value = Peak4k64ThreadReadSpeed, Measure = "МБ/с" },
                new LongSpecification { Name = "Пиковая скорость записи (4К, 64 потока)", Value = Peak4k64ThreadWriteSpeed, Measure = "МБ/с" },
                new LongSpecification { Name = "Пиковая смешанная скорость I/O (4К, 64 потока)", Value = Peak4k64ThreadMixedIoSpeed, Measure = "МБ/с" },
                new LongSpecification { Name = "Средняя скорость чтения (4К, 64 потока)", Value = Avg4k64ThreadReadSpeed, Measure = "МБ/с" },
                new LongSpecification { Name = "Средняя скорость записи (4К, 64 потока)", Value = Avg4k64ThreadWriteSpeed, Measure = "МБ/с" },
                new LongSpecification { Name = "Средняя смешанная скорость I/O (4К, 64 потока)", Value = Avg4k64ThreadMixedIoSpeed, Measure = "МБ/с" },
            };
            AddMetricsCategory(specifications, perfomanceMetrics);

            return specifications;
        }
    }
}