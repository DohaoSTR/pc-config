using PCConfig.Model.Contexts;
using PCConfig.Model.PcPartPicker.Entities.Motherboard;

namespace PCConfig.Model.PcPartPicker.LongResult
{
    public class MotherboardLongResult : LongPartViewData
    {
        public string? FormFactor { get; set; }
        public string? Chipset { get; set; }
        public int? MemoryMax { get; set; }
        public string? MemoryType { get; set; }
        public int? MemorySlots { get; set; }
        public string? Color { get; set; }
        public string? SupportsECC { get; set; }
        public string? RAIDSupport { get; set; }
        public string? Model { get; set; }
        public string? OnboardVideo { get; set; }
        public string? WiFiStandard { get; set; }
        public double? NetworkAdapterSpeed { get; set; }

        public int? PCIeX16Slots { get; set; }
        public int? PCIeX8Slots { get; set; }
        public int? PCIeX4Slots { get; set; }
        public int? PCIeX1Slots { get; set; }
        public int? PCISlots { get; set; }
        public int? MiniPCIeSlots { get; set; }
        public int? HalfMiniPCIeSlots { get; set; }
        public int? MiniPCIeMsataSlots { get; set; }
        public int? MsataSlots { get; set; }
        public int? SATA6_0 { get; set; }
        public int? PATA100 { get; set; }
        public int? SATA3_0 { get; set; }
        public int? ESATA6_0 { get; set; }
        public int? U2 { get; set; }
        public int? ESATA3_0 { get; set; }
        public int? SAS3_0 { get; set; }
        public int? PATA133 { get; set; }
        public int? SAS12_0 { get; set; }
        public int? SAS6_0 { get; set; }
        public int? SATA1_5 { get; set; }

        public string? SpeedsIds { get; set; }
        public string? SocketsIds { get; set; }
        public string? MultiIntersIds { get; set; }
        public string? SlotsIds { get; set; }
        public string? EthernetIds { get; set; }

        public override IEnumerable<LongSpecification> GetSpecificationList()
        {
            var specifications = new List<LongSpecification>
            {
                new LongSpecification { Name = "Характеристики комплектующей", LongSpecificationType = LongSpecificationType.Category },

                new LongSpecification { Name = "Форм-фактор", Value = FormFactor },
                new LongSpecification { Name = "Чипсет", Value = Chipset },
                new LongSpecification { Name = "Максимальный объем памяти", Value = MemoryMax, Measure = "ГБ" },
                new LongSpecification { Name = "Тип памяти", Value = MemoryType },
                new LongSpecification { Name = "Количество слотов памяти", Value = MemorySlots },
                new LongSpecification { Name = "Цвет", Value = Color },
                new LongSpecification { Name = "Поддержка ECC", Value = SupportsECC },
                new LongSpecification { Name = "Поддержка RAID", Value = RAIDSupport },
                new LongSpecification { Name = "Модель", Value = Model },
                new LongSpecification { Name = "Встроенное видео", Value = OnboardVideo },
                new LongSpecification { Name = "Стандарт Wi-Fi", Value = WiFiStandard },
                new LongSpecification { Name = "Скорость сетевого адаптера", Value = NetworkAdapterSpeed, Measure = "Гбит/с" }
            };

            List<LongSpecification> connectors = new()
            {
                new LongSpecification { Name = "Интерфейсы подключения", LongSpecificationType = LongSpecificationType.Category },
                new LongSpecification { Name = "PCIe x16", Value = PCIeX16Slots, Measure = "шт." },
                new LongSpecification { Name = "PCIe x8", Value = PCIeX8Slots, Measure = "шт." },
                new LongSpecification { Name = "PCIe x4", Value = PCIeX4Slots, Measure = "шт." },
                new LongSpecification { Name = "PCIe x1", Value = PCIeX1Slots, Measure = "шт." },
                new LongSpecification { Name = "PCI", Value = PCISlots, Measure = "шт." },
                new LongSpecification { Name = "Mini PCIe", Value = MiniPCIeSlots, Measure = "шт." },
                new LongSpecification { Name = "Half Mini PCIe", Value = HalfMiniPCIeSlots, Measure = "шт." },
                new LongSpecification { Name = "Mini PCIe mSATA", Value = MiniPCIeMsataSlots, Measure = "шт." },
                new LongSpecification { Name = "mSATA", Value = MsataSlots, Measure = "шт." },
                new LongSpecification { Name = "SATA 6.0", Value = SATA6_0, Measure = "шт." },
                new LongSpecification { Name = "PATA 100", Value = PATA100, Measure = "шт." },
                new LongSpecification { Name = "SATA 3.0", Value = SATA3_0, Measure = "шт." },
                new LongSpecification { Name = "eSATA 6.0", Value = ESATA6_0, Measure = "шт." },
                new LongSpecification { Name = "U.2", Value = U2, Measure = "шт." },
                new LongSpecification { Name = "eSATA 3.0", Value = ESATA3_0, Measure = "шт." },
                new LongSpecification { Name = "SAS 3.0", Value = SAS3_0, Measure = "шт." },
                new LongSpecification { Name = "PATA 133", Value = PATA133, Measure = "шт." },
                new LongSpecification { Name = "SAS 12.0", Value = SAS12_0, Measure = "шт." },
                new LongSpecification { Name = "SAS 6.0", Value = SAS6_0, Measure = "шт." },
                new LongSpecification { Name = "SATA 1.5", Value = SATA1_5, Measure = "шт." },
            };
            AddMetricsCategory(specifications, connectors);

            PCPartPickerContext context = new PCPartPickerContext();

            if (SpeedsIds != null)
            {
                specifications.Add(new LongSpecification { Name = "Доступные скорости оперативной памяти", LongSpecificationType = LongSpecificationType.Category });

                List<string> speedsIds = SpeedsIds.Split(",").ToList();
                foreach (string id in speedsIds)
                {
                    MotherboardMemorySpeed entity = context.MotherboardMemorySpeeds.Where(x => x.Id == Convert.ToInt32(id)).First();

                    List<LongSpecification> specification = new List<LongSpecification>
                    {
                        new LongSpecification { Name = "Тип памяти", Value = entity.MemoryType },
                        new LongSpecification { Name = "Скорость", Value = entity.MemorySpeed, Measure = "МГц" },
                    };

                    specifications.AddRange(specification);
                }
            }

            if (SocketsIds != null)
            {
                specifications.Add(new LongSpecification { Name = "Сокеты материнской платы", LongSpecificationType = LongSpecificationType.Category });

                List<string> socketsIds = SocketsIds.Split(",").ToList();
                foreach (string id in socketsIds)
                {
                    MotherboardSocket entity = context.MotherboardSockets.Where(x => x.Id == Convert.ToInt32(id)).First();

                    List<LongSpecification> specification = new List<LongSpecification>
                    {
                        new LongSpecification { Name = "Сокет", Value = entity.SocketName },
                        new LongSpecification { Name = "Количество", Value = entity.SocketCount, Measure = "шт." },
                    };

                    specifications.AddRange(specification);
                }
            }

            if (MultiIntersIds != null)
            {
                specifications.Add(new LongSpecification { Name = "SLI/CrossFire", LongSpecificationType = LongSpecificationType.Category });

                List<string> multiIntersIds = MultiIntersIds.Split(",").ToList();
                foreach (string id in multiIntersIds)
                {
                    MotherboardMultiInterface entity = context.MotherboardMultiInterfaces.Where(x => x.Id == Convert.ToInt32(id)).First();

                    List<LongSpecification> specification = new List<LongSpecification>
                    {
                        new LongSpecification { Name = "Количество интерфейсов", Value = entity.WaysCount, Measure = "шт." },
                        new LongSpecification { Name = "Технология", Value = entity.NameTechnology },
                    };

                    specifications.AddRange(specification);
                }
            }

            if (SlotsIds != null)
            {
                List<string> slotsIds = SlotsIds.Split(",").ToList();
                int index = 1;
                foreach (string id in slotsIds)
                {
                    MotherboardM2Slots entity = context.MotherboardM2Slots.Where(x => x.Id == Convert.ToInt32(id)).First();

                    List<LongSpecification> specification = new List<LongSpecification>
                    {
                        new LongSpecification { Name = $"Разъем M.2 №{index}", LongSpecificationType = LongSpecificationType.Category },

                        new LongSpecification { Name = "Стандартный размер", Value = entity.StandardSize, Measure = "шт." },
                        new LongSpecification { Name = "Название ключа", Value = entity.KeyName },
                        new LongSpecification { Name = "Описание", Value = entity.Description },
                    };

                    specifications.AddRange(specification);
                    index++;
                }
            }

            if (EthernetIds != null)
            {
                List<string> ethernetIds = EthernetIds.Split(",").ToList();
                int index = 1;
                foreach (string id in ethernetIds)
                {
                    MotherboardEthernet entity = context.MotherboardEthernets.Where(x => x.Id == Convert.ToInt32(id)).First();

                    List<LongSpecification> specification =
                    [
                        new LongSpecification { Name = $"Встроенный сетевой адаптер №{index}", LongSpecificationType = LongSpecificationType.Category },

                        new LongSpecification { Name = "Количество сетевых адаптеров", Value = entity.NetworkAdapterCount, Measure = "шт." },
                        new LongSpecification { Name = "Скорость сетевого адаптера", Value = entity.NetworkAdapterSpeed, Measure = entity.SpeedMeasure },
                        new LongSpecification { Name = "Тип сетевого адаптера", Value = entity.NetworkAdapter },
                    ];

                    specifications.AddRange(specification);
                    index++;
                }
            }

            return specifications;
        }
    }
}
