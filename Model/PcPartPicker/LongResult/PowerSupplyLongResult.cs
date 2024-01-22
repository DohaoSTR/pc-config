using PCConfig.Model.Contexts;
using PCConfig.Model.PcPartPicker.Entities.PowerSupply;

namespace PCConfig.Model.PcPartPicker.LongResult
{
    public class PowerSupplyLongResult : LongPartViewData
    {
        public string? Model { get; set; }
        public string? Type { get; set; }
        public string? EfficiencyRating { get; set; }
        public double? Wattage { get; set; }
        public double? Length { get; set; }
        public string? Modular { get; set; }
        public string? Color { get; set; }
        public string? Fan { get; set; }

        public int? ATX4PinConnectors { get; set; }
        public int? EPS8PinConnectors { get; set; }
        public int? PCIe124Pin12VHPWRConnectors { get; set; }
        public int? PCIe12PinConnectors { get; set; }
        public int? PCIe8PinConnectors { get; set; }
        public int? PCIe62PinConnectors { get; set; }
        public int? PCIe6PinConnectors { get; set; }
        public int? SATAConnectors { get; set; }
        public int? Molex4PinConnectors { get; set; }

        public string? OutputsIds { get; set; }

        public override IEnumerable<LongSpecification> GetSpecificationList()
        {
            var specifications = new List<LongSpecification>
            {
                new LongSpecification { Name = "Характеристики комплектующей", LongSpecificationType = LongSpecificationType.Category },

                new LongSpecification { Name = "Модель", Value = Model },
                new LongSpecification { Name = "Тип", Value = Type },
                new LongSpecification { Name = "Эффективность", Value = EfficiencyRating },
                new LongSpecification { Name = "Мощность", Value = Wattage, Measure = "Вт" },
                new LongSpecification { Name = "Длина", Value = Length, Measure = "мм" },
                new LongSpecification { Name = "Модульность", Value = Modular },
                new LongSpecification { Name = "Цвет", Value = Color },
                new LongSpecification { Name = "Вентилятор", Value = Fan }
            };

            List<LongSpecification> connectors = new()
            {
                new LongSpecification { Name = "Коннекторы", LongSpecificationType = LongSpecificationType.Category },
                new LongSpecification { Name = "ATX 4-pin", Value = ATX4PinConnectors, Measure = "шт." },
                new LongSpecification { Name = "EPS 8-pin", Value = EPS8PinConnectors, Measure = "шт." },
                new LongSpecification { Name = "PCIe 12+4-pin 12V HPPWR", Value = PCIe124Pin12VHPWRConnectors, Measure = "шт." },
                new LongSpecification { Name = "PCIe 12-pin", Value = PCIe12PinConnectors, Measure = "шт." },
                new LongSpecification { Name = "PCIe 8-pin", Value = PCIe8PinConnectors, Measure = "шт." },
                new LongSpecification { Name = "PCIe 6+2-pin", Value = PCIe62PinConnectors, Measure = "шт." },
                new LongSpecification { Name = "PCIe 6-pin", Value = PCIe6PinConnectors, Measure = "шт." },
                new LongSpecification { Name = "SATA", Value = SATAConnectors, Measure = "шт." },
                new LongSpecification { Name = "Molex 4-pin", Value = Molex4PinConnectors, Measure = "шт." },
            };
            AddMetricsCategory(specifications, connectors);

            PCPartPickerContext context = new PCPartPickerContext();

            if (OutputsIds != null)
            {
                List<string> ids = OutputsIds.Split(",").ToList();
                int index = 1;
                foreach (string id in ids)
                {
                    PowerSupplyOutput entity = context.PowerSupplyOutputs.Where(x => x.Id == Convert.ToInt32(id)).First();

                    List<LongSpecification> specification = new List<LongSpecification>
                    {
                        new LongSpecification { Name = $"Электрические параметры №{index}", LongSpecificationType = LongSpecificationType.Category },
                        new LongSpecification { Name = "Режим напряжения", Value = entity.VoltageMode },
                        new LongSpecification { Name = "Амперы", Value = entity.Ampere, Measure = "А" },
                        new LongSpecification { Name = "Мощность", Value = entity.Power, Measure = "Вт" },
                        new LongSpecification { Name = "Комбинированный", Value = entity.Combined },
                        new LongSpecification { Name = "Режим постоянного тока (DC)", Value = entity.DCMode },
                        new LongSpecification { Name = "Описание", Value = entity.Description },
                    };

                    specifications.AddRange(specification);
                    index++;
                }
            }

            return specifications;
        }
    }
}
