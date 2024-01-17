using PCConfig.Model.Converters;

namespace PCConfig.Model.PcPartPicker.ShortViewData
{
    public class HDDShortResult : PartViewData
    {
        public double? SpindleSpeed { get; set; }

        public string? Interface { get; set; }

        public double? Cache { get; set; }

        public string? CacheMeasure { get; set; }

        public double? Capacity { get; set; }

        public string? CapacityMeasure { get; set; }

        public Tuple<string, string?> Parse(object value)
        {
            if (value != null)
            {
                string stringValue = value.ToString();

                if (value == "PATA 100")
                {
                    return new Tuple<string, string?>(stringValue, null);
                }

                string[] parts = stringValue.Split(new[] { ' ' }, 3);

                return new Tuple<string, string?>(parts[0], parts[1]);
            }

            return null;
        }

        public override IEnumerable<ShortSpecification> GetSpecificationList()
        {
            MeasureConverter measureConverter = new MeasureConverter();
            Tuple<string, string?> tuple = Parse(Interface);

            string? interfaceName = null;
            string? interfaceSpeed = null;
            if (tuple != null)
            {
                interfaceName = tuple.Item1;
                interfaceSpeed = tuple.Item2;
            }

            var values = new List<ShortSpecification>
            {
                new ShortSpecification
                {
                    Name = "Интерфейс",
                    Value = interfaceName
                },
                new ShortSpecification
                {
                    Name = "Пропускная способность интерфейса",
                    Value = interfaceSpeed,
                    Measure = "Гбит/с"
                },
                new ShortSpecification
                {
                    Name = "Скорость вращения шпинделя",
                    Value = SpindleSpeed,
                    Measure = "об/мин"
                },
                new ShortSpecification
                {
                    Name = "Объем HDD",
                    Value = Capacity,
                    Measure = measureConverter.Convert(CapacityMeasure, null, null, null).ToString()
                },
                new ShortSpecification
                {
                    Name = "Объем кэш-памяти",
                    Value = Cache,
                    Measure = measureConverter.Convert(CacheMeasure, null, null, null).ToString()
                }
            };

            return values;
        }
    }
}
