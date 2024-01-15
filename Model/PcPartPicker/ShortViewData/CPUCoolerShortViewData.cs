using PCConfig.Model.Converters;

namespace PCConfig.Model.PcPartPicker.ShortViewData
{
    public class CPUCoolerShortViewData : PartViewData
    {
        public string? Socket { get; set; }

        public double? MinRpm { get; set; }

        public double? MaxRpm { get; set; }

        public double? MinNoiseLevel { get; set; }

        public double? MaxNoiseLevel { get; set; }

        public override IEnumerable<ShortSpecification> GetSpecificationList()
        {
            FanSizeConverter fanSizeConverter = new FanSizeConverter();

            var values = new List<ShortSpecification>
            {
                new ShortSpecification
                {
                    Name = "Сокет",
                    Value = Socket
                },
                new ShortSpecification
                {
                    Name = "Максимальная скорость вращения",
                    Value = MaxRpm,
                    Measure = "об/мин"
                },
                new ShortSpecification
                {
                    Name = "Минимальная скорость вращения ",
                    Value = MinRpm,
                    Measure = "об/мин"
                },
                new ShortSpecification
                {
                    Name = "Максимальный уровень шума",
                    Value = MaxNoiseLevel,
                    Measure = "дБ"
                },
                new ShortSpecification
                {
                    Name = "Минимальный уровень шума",
                    Value = MinNoiseLevel,
                    Measure = "дБ"
                }
            };

            return values;
        }
    }
}
