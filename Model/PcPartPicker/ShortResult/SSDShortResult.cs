using PCConfig.Model.Converters;

namespace PCConfig.Model.PcPartPicker.ShortViewData
{
    public class SSDShortResult : PartViewData
    {
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

                if (value == "SATA 6.0 Gb/s")
                {
                    string[] parts = stringValue.Split(new[] { ' ' }, 3);

                    return new Tuple<string, string?>(parts[0], parts[1]);
                }
                else
                {
                    return new Tuple<string, string?>(stringValue, null);
                }
            }

            return null;
        }

        public override IEnumerable<ShortSpecification> GetSpecificationList()
        {
            MeasureConverter measureConverter = new MeasureConverter();
            Tuple<string, string?> tuple = Parse(Interface);

            var values = new List<ShortSpecification>
            {
                new ShortSpecification
                {
                    Name = "Интерфейс",
                    Value = tuple.Item1
                },
                new ShortSpecification
                {
                    Name = "Пропускная способность интерфейса",
                    Value = tuple.Item2,
                    Measure = "Гбит/с"
                },
                new ShortSpecification
                {
                    Name = "Объем SSD",
                    Value = Capacity,
                    Measure = measureConverter.Convert(CapacityMeasure, null, null, null).ToString()
                },
                new ShortSpecification
                {
                    Name = "Объем кэш-памяти",
                    Value = Cache,
                    Measure = measureConverter.Convert(CacheMeasure, null, null, null).ToString()
                },
            };

            return values;
        }
    }
}
