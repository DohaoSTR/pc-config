using PCConfig.Model.Converters;

namespace PCConfig.Model.PcPartPicker.ShortViewData
{
    public class CaseFanShortResult : PartViewData
    {
        public int? Quantity { get; set; }

        public double? Size { get; set; }

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
                    Name = "Количество вентиляторов в комплекте",
                    Value = Quantity
                },
                new ShortSpecification
                {
                    Name = "Размер вентилятора",
                    Value = fanSizeConverter.Convert(Size, null, null, null),
                    Measure = "мм"
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
