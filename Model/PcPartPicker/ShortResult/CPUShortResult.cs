using PCConfig.Model.Converters;

namespace PCConfig.Model.PcPartPicker.ShortViewData
{
    public class CPUShortResult : PartViewData
    {
        public int? CoreCount { get; set; }

        public double? PerformanceCoreClock { get; set; }

        public double? PerformanceBoostClock { get; set; }

        public int? TDP { get; set; }

        public string? IncludesCooler { get; set; }

        public string? IntegratedGraphics { get; set; }

        public string? Socket { get; set; }


        public int? GamingPercentage { get; set; }

        public int? DesktopPercentage { get; set; }

        public int? WorkstationPercentage { get; set; }


        public override IEnumerable<ShortSpecification> GetSpecificationList()
        {
            IntegratedGraphicsConverter integratedGraphicsConverter = new IntegratedGraphicsConverter();
            YesNoConverter yesNoConverter = new YesNoConverter();

            var values = new List<ShortSpecification>
            {
                new ShortSpecification { Name = "Количество ядер", Value = CoreCount },
                new ShortSpecification { Name = "Базовая частота процессора", Value = PerformanceCoreClock, Measure = "ГГц" },
                new ShortSpecification { Name = "Максимальная частота в турбо режиме", Value = PerformanceBoostClock, Measure = "ГГц" },
                new ShortSpecification { Name = "Тепловыделение (TDP)", Value = TDP, Measure = "Вт" },
                new ShortSpecification { Name = "Система охлаждения в комплекте", Value = yesNoConverter.Convert(IncludesCooler, null, null, null).ToString() },
                new ShortSpecification { Name = "Интегрированное графическое ядро", Value = integratedGraphicsConverter.Convert(IntegratedGraphics, null, null, null).ToString() },
                new ShortSpecification { Name = "Сокет", Value = Socket.ToString() },
            };

            return values;
        }
    }
}
