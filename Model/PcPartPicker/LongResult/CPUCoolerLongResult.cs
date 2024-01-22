using PCConfig.Model.Contexts;
using PCConfig.Model.PcPartPicker.Entities.CPUCooler;

namespace PCConfig.Model.PcPartPicker.LongResult
{
    public class CPUCoolerLongResult : LongPartViewData
    {
        public string? Model { get; set; }
        public double? Height { get; set; }
        public double? WaterCooled { get; set; }
        public string? Fan { get; set; }
        public string? Color { get; set; }
        public string? Bearing { get; set; }
        public double? MinRPM { get; set; }
        public double? MaxRPM { get; set; }
        public double? MinNoiseLevel { get; set; }
        public double? MaxNoiseLevel { get; set; }

        public string? SocketsIds { get; set; }

        public override IEnumerable<LongSpecification> GetSpecificationList()
        {
            var specifications = new List<LongSpecification>
            {
                new LongSpecification { Name = "Характеристики комплектующей", LongSpecificationType = LongSpecificationType.Category },

                new LongSpecification { Name = "Модель", Value = Model },
                new LongSpecification { Name = "Высота", Value = Height, Measure = "мм" },
                new LongSpecification { Name = "Водяное охлаждение", Value = WaterCooled },
                new LongSpecification { Name = "Вентилятор", Value = Fan },
                new LongSpecification { Name = "Цвет", Value = Color },
                new LongSpecification { Name = "Подшипник", Value = Bearing },
                new LongSpecification { Name = "Минимальные обороты вентилятора", Value = MinRPM, Measure = "об/мин" },
                new LongSpecification { Name = "Максимальные обороты вентилятора", Value = MaxRPM, Measure = "об/мин" },
                new LongSpecification { Name = "Минимальный уровень шума", Value = MinNoiseLevel, Measure = "дБ" },
                new LongSpecification { Name = "Максимальный уровень шума", Value = MaxNoiseLevel, Measure = "дБ" },
            };

            PCPartPickerContext context = new PCPartPickerContext();

            if (SocketsIds != null)
            {
                specifications.Add(new LongSpecification { Name = "Совместимые сокеты", LongSpecificationType = LongSpecificationType.Category });

                List<string> ids = SocketsIds.Split(",").ToList();
                int index = 1;
                foreach (string id in ids)
                {
                    CPUCoolerSocket entity = context.CPUCoolerSockets.Where(x => x.Id == Convert.ToInt32(id)).First();

                    List<LongSpecification> specification = new List<LongSpecification>
                    {
                        new LongSpecification { Name = $"Сокет №{index}", Value = entity.Socket },
                    };

                    specifications.AddRange(specification);
                    index++;
                }
            }

            return specifications;
        }
    }
}