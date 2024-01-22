using PCConfig.Model.Contexts;
using PCConfig.Model.Converters;
using PCConfig.Model.PcPartPicker.Entities.CaseFan;

namespace PCConfig.Model.PcPartPicker.LongResult
{
    public class CaseFanLongResult : LongPartViewData
    {
        public string? Model { get; set; }
        public double? Size { get; set; }
        public string? Color { get; set; }
        public int? Quantity { get; set; }
        public string? PWM { get; set; }
        public string? LED { get; set; }
        public string? Controller { get; set; }
        public double? StaticPressure { get; set; }
        public string? BearingType { get; set; }
        public double? MinRPM { get; set; }
        public double? MaxRPM { get; set; }
        public double? MinAirflow { get; set; }
        public double? MaxAirflow { get; set; }
        public double? MinNoiseLevel { get; set; }
        public double? MaxNoiseLevel { get; set; }

        public string? ConnectorsIds { get; set; }

        public override IEnumerable<LongSpecification> GetSpecificationList()
        {
            FanSizeConverter fanSizeConverter = new FanSizeConverter();

            var specifications = new List<LongSpecification>
            {
                new LongSpecification { Name = "Характеристики комплектующей", LongSpecificationType = LongSpecificationType.Category },

                new LongSpecification { Name = "Размер вентилятора", Value = fanSizeConverter.Convert(Size, null, null, null), Measure = "мм"},
                new LongSpecification { Name = "Модель", Value = Model },
                new LongSpecification { Name = "Цвет", Value = Color },
                new LongSpecification { Name = "Количество", Value = Quantity, Measure = "шт." },
                new LongSpecification { Name = "PWM", Value = PWM },
                new LongSpecification { Name = "LED", Value = LED },
                new LongSpecification { Name = "Контроллер", Value = Controller },
                new LongSpecification { Name = "Статическое давление", Value = StaticPressure, Measure = "мм водяного столба" },
                new LongSpecification { Name = "Тип подшипника", Value = BearingType },
                new LongSpecification { Name = "Минимальные обороты вентилятора", Value = MinRPM, Measure = "об/мин" },
                new LongSpecification { Name = "Максимальные обороты вентилятора", Value = MaxRPM, Measure = "об/мин" },
                new LongSpecification { Name = "Минимальный объем воздуха", Value = MinAirflow, Measure = "куб. м/ч" },
                new LongSpecification { Name = "Максимальный объем воздуха", Value = MaxAirflow, Measure = "куб. м/ч" },
                new LongSpecification { Name = "Минимальный уровень шума", Value = MinNoiseLevel, Measure = "дБ" },
                new LongSpecification { Name = "Максимальный уровень шума", Value = MaxNoiseLevel, Measure = "дБ" },
            };

            PCPartPickerContext context = new PCPartPickerContext();

            if (ConnectorsIds != null)
            {
                List<string> ids = ConnectorsIds.Split(",").ToList();

                int index = 1;
                foreach (string id in ids)
                {
                    CaseFanConnector entity = context.CaseFanConnectors.Where(x => x.Id == Convert.ToInt32(id)).First();

                    List<LongSpecification> specification =
                    [
                        new LongSpecification { Name = $"Характеристики коннектора №{index}", LongSpecificationType = LongSpecificationType.Category },

                        new LongSpecification { Name = "Количество пинов", Value = entity.PinCount, Measure = "шт." },
                        new LongSpecification { Name = "Количество вольт", Value = entity.VoltCount, Measure = "шт." },
                        new LongSpecification { Name = "RGB-подсветка", Value = entity.RGB },
                        new LongSpecification { Name = "Проприетарный разъем", Value = entity.Proprietary },
                        new LongSpecification { Name = "Адресная подсветка", Value = entity.Addressable },
                        new LongSpecification { Name = "PWM-регулирование", Value = entity.PWM },
                    ];

                    specifications.AddRange(specification);
                    index++;
                }
            }

            return specifications;
        }
    }
}