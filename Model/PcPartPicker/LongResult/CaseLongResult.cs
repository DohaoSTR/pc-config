using PCConfig.Model.Contexts;
using PCConfig.Model.PcPartPicker.Entities.Case;

namespace PCConfig.Model.PcPartPicker.LongResult
{
    public class CaseLongResult : LongPartViewData
    {
        public double? PowerSupply { get; set; }
        public double? MaximumVideoCardLengthWith { get; set; }
        public double? MaximumVideoCardLengthWithout { get; set; }
        public string? Type { get; set; }
        public string? Color { get; set; }
        public string? SidePanel { get; set; }
        public string? HasPowerSupply { get; set; }
        public string? PowerSupplyShroud { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public string? Model { get; set; }
        public double? Volume { get; set; }

        public string? SlotsIds { get; set; }
        public string? DriveBayIds { get; set; }
        public string? FrontPanelIds { get; set; }
        public string? FormFactors { get; set; }

        public override IEnumerable<LongSpecification> GetSpecificationList()
        {
            var specifications = new List<LongSpecification>
            {
                new LongSpecification { Name = "Характеристики комплектующей", LongSpecificationType = LongSpecificationType.Category },

                new LongSpecification { Name = "Мощность блока питания", Value = PowerSupply, Measure = "Вт" },
                new LongSpecification { Name = "Максимальная длина видеокарты с блоком", Value = MaximumVideoCardLengthWith, Measure = "мм" },
                new LongSpecification { Name = "Максимальная длина видеокарты без блока", Value = MaximumVideoCardLengthWithout, Measure = "мм" },
                new LongSpecification { Name = "Тип", Value = Type },
                new LongSpecification { Name = "Цвет", Value = Color },
                new LongSpecification { Name = "Боковая панель", Value = SidePanel },
                new LongSpecification { Name = "Наличие блока питания", Value = HasPowerSupply },
                new LongSpecification { Name = "Кожух блока питания", Value = PowerSupplyShroud },
                new LongSpecification { Name = "Длина", Value = Length, Measure = "мм" },
                new LongSpecification { Name = "Ширина", Value = Width, Measure = "мм" },
                new LongSpecification { Name = "Высота", Value = Height, Measure = "мм" },
                new LongSpecification { Name = "Модель", Value = Model },
                new LongSpecification { Name = "Объем", Value = Volume, Measure = "л" },
            };

            PCPartPickerContext context = new PCPartPickerContext();

            if (SlotsIds != null)
            {
                List<string> slotsIds = SlotsIds.Split(",").ToList();
                int index = 1;
                foreach (string id in slotsIds)
                {
                    CaseExpansionSlot entity = context.CaseExpansionSlots.Where(x => x.Id == Convert.ToInt32(id)).First();

                    List<LongSpecification> specification = new List<LongSpecification>
                    {
                        new LongSpecification { Name = $"Слот расширения №{index}", LongSpecificationType = LongSpecificationType.Category },

                        new LongSpecification { Name = "Количество слотов", Value = entity.Count, Measure = "шт." },
                        new LongSpecification { Name = "Тип слота", Value = entity.Type },
                        new LongSpecification { Name = "Riser", Value = entity.Riser },
                    };

                    specifications.AddRange(specification);
                    index++;
                }
            }

            if (DriveBayIds != null)
            {
                List<string> driveBayIds = DriveBayIds.Split(",").ToList();
                int index = 1;
                foreach (string id in driveBayIds)
                {
                    CaseDriveBay entity = context.CaseDriveBays.Where(x => x.Id == Convert.ToInt32(id)).First();

                    List<LongSpecification> specification = new List<LongSpecification>
                    {
                        new LongSpecification { Name = $"Отсек для устройств №{index}", LongSpecificationType = LongSpecificationType.Category },

                        new LongSpecification { Name = "Количество отсеков", Value = entity.Count, Measure = "шт." },
                        new LongSpecification { Name = "Тип отсека", Value = entity.Type },
                        new LongSpecification { Name = "Формат", Value = entity.Format, Measure = "дюймы" },
                    };

                    specifications.AddRange(specification);
                    index++;
                }
            }

            if (FrontPanelIds != null)
            {
                List<string> frontPanelIds = FrontPanelIds.Split(",").ToList();
                int index = 1;
                foreach (string id in frontPanelIds)
                {
                    CaseFrontPanelUSB entity = context.CaseFrontPanels.Where(x => x.Id == Convert.ToInt32(id)).First();

                    List<LongSpecification> specification = new List<LongSpecification>
                    {
                        new LongSpecification { Name = $"USB порт №{index}", Value = entity.Value, Measure = "шт." },
                    };

                    specifications.AddRange(specification);
                    index++;
                }
            }

            if (FormFactors != null)
            {
                List<string> formFactorsIds = FormFactors.Split(",").ToList();
                foreach (string id in formFactorsIds)
                {
                    CaseMotherboardFormFactor entity = context.CaseMotherboardFormFactors.Where(x => x.Id == Convert.ToInt32(id)).First();

                    List<LongSpecification> specification = new List<LongSpecification>
                    {
                        new LongSpecification { Name = "Форм-фактор материнской платы", Value = entity.Value },
                    };

                    specifications.AddRange(specification);
                }
            }

            return specifications;
        }
    }
}
