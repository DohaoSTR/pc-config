using PCConfig.Model.Contexts;
using PCConfig.Model.PcPartPicker.Entities.GPU;

namespace PCConfig.Model.PcPartPicker.LongResult
{
    public class GPULongResult : LongPartViewData
    {
        public string? Model { get; set; }
        public string? Chipset { get; set; }
        public double? Memory { get; set; }
        public string? MemoryType { get; set; }
        public int? CoreClock { get; set; }
        public int? BoostClock { get; set; }
        public int? EffectiveMemoryClock { get; set; }
        public string? Color { get; set; }
        public string? FrameSync { get; set; }
        public int? TDP { get; set; }
        public int? RadiatorMM { get; set; }
        public int? FansCount { get; set; }

        public string? Interface { get; set; }
        public int? Length { get; set; }
        public int? CaseExpansionSlotWidth { get; set; }
        public int? TotalSlotWidth { get; set; }

        public int? HDMIOutputs { get; set; }
        public int? DisplayPortOutputs { get; set; }
        public int? HDMI2_1aOutputs { get; set; }
        public int? DisplayPort1_4Outputs { get; set; }
        public int? DisplayPort1_4aOutputs { get; set; }
        public int? DVIDDualLinkOutputs { get; set; }
        public int? HDMI2_1Outputs { get; set; }
        public int? DisplayPort2_1Outputs { get; set; }
        public int? DisplayPort2_0Outputs { get; set; }
        public int? HDMI2_0bOutputs { get; set; }
        public int? DVII_DualLinkOutputs { get; set; }
        public int? USBTypeCOutputs { get; set; }
        public int? VGAOutputs { get; set; }
        public int? VirtualLinkOutputs { get; set; }
        public int? DVIDSingleLinkOutputs { get; set; }
        public int? MiniDisplayPort2_1Outputs { get; set; }
        public int? HDMI2_0Outputs { get; set; }
        public int? DVIOutputs { get; set; }
        public int? MiniDisplayPortOutputs { get; set; }
        public int? HDMI1_4Outputs { get; set; }
        public int? MiniDisplayPort1_4aOutputs { get; set; }
        public int? MiniDisplayPort1_4Outputs { get; set; }
        public int? VHDCIOutputs { get; set; }
        public int? DVII_SingleLinkOutputs { get; set; }
        public int? SVideoOutputs { get; set; }
        public int? MiniHDMIOutputs { get; set; }
        public int? DisplayPort1_3Outputs { get; set; }
        public int? DVIAOutputs { get; set; }

        public double? Effective3DGamingSpeed { get; set; }
        public double? AvgLocallyDeformablePrt { get; set; }
        public double? AvgHighDynamicRangeLighting { get; set; }
        public double? AvgRenderTargetArrayGShader { get; set; }
        public double? AvgNBodyParticleSystem { get; set; }
        public double? LocallyDeformablePrt { get; set; }
        public double? HighDynamicRangeLighting { get; set; }
        public double? RenderTargetArrayGShader { get; set; }
        public double? NBodyParticleSystem { get; set; }
        public double? ParallaxOcclusionMapping { get; set; }
        public double? ForceSplattedFlocking { get; set; }
        public double? AvgParallaxOcclusionMapping { get; set; }
        public double? AvgForceSplattedFlocking { get; set; }

        public int? GamingPercentage { get; set; }
        public int? DesktopPercentage { get; set; }
        public int? WorkstationPercentage { get; set; }

        public string? ExternalPowerIds { get; set; }
        public string? MultiInterfaceIds { get; set; }

        public override IEnumerable<LongSpecification> GetSpecificationList()
        {
            var specifications = new List<LongSpecification>
            {
                new LongSpecification { Name = "Характеристики комплектующей", LongSpecificationType = LongSpecificationType.Category },
                new LongSpecification { Name = "Модель", Value = Model },
                new LongSpecification { Name = "Чипсет", Value = Chipset },
                new LongSpecification { Name = "Базовая частота памяти", Value = Memory, Measure = "МГц" },
                new LongSpecification { Name = "Тип памяти", Value = MemoryType },
                new LongSpecification { Name = "Базовая частота работы видеочипа", Value = CoreClock, Measure = "МГц" },
                new LongSpecification { Name = "Тактовая частота Boost", Value = BoostClock, Measure = "МГц" },
                new LongSpecification { Name = "Эффективная частота памяти", Value = EffectiveMemoryClock, Measure = "МГц" },
                new LongSpecification { Name = "Цвет", Value = Color },
                new LongSpecification { Name = "Frame Sync", Value = FrameSync },
                new LongSpecification { Name = "TDP", Value = TDP, Measure = "Вт" },
                new LongSpecification { Name = "Размер радиатора", Value = RadiatorMM, Measure = "мм" },
                new LongSpecification { Name = "Количество вентиляторов", Value = FansCount, Measure = "шт." },

                new LongSpecification { Name = "Интерфейс подключения", Value = Interface },
                new LongSpecification { Name = "Длина", Value = Length, Measure = "мм" },
                new LongSpecification { Name = "Ширина слота корпуса", Value = CaseExpansionSlotWidth, Measure = "мм" },
                new LongSpecification { Name = "Общая ширина слота", Value = TotalSlotWidth, Measure = "мм" },
            };

            List<LongSpecification> outputs = new()
            {
                new LongSpecification { Name = "Выходы", LongSpecificationType = LongSpecificationType.Category },
                new LongSpecification { Name = "HDMI", Value = HDMIOutputs, Measure = "шт." },
                new LongSpecification { Name = "DisplayPort", Value = DisplayPortOutputs, Measure = "шт." },
                new LongSpecification { Name = "HDMI 2.1a", Value = HDMI2_1aOutputs, Measure = "шт." },
                new LongSpecification { Name = "DisplayPort 1.4", Value = DisplayPort1_4Outputs, Measure = "шт." },
                new LongSpecification { Name = "DisplayPort 1.4a", Value = DisplayPort1_4aOutputs, Measure = "шт." },
                new LongSpecification { Name = "DVI-D Dual Link", Value = DVIDDualLinkOutputs, Measure = "шт." },
                new LongSpecification { Name = "HDMI 2.1", Value = HDMI2_1Outputs, Measure = "шт." },
                new LongSpecification { Name = "DisplayPort 2.1", Value = DisplayPort2_1Outputs, Measure = "шт." },
                new LongSpecification { Name = "DisplayPort 2.0", Value = DisplayPort2_0Outputs, Measure = "шт." },
                new LongSpecification { Name = "HDMI 2.0b", Value = HDMI2_0bOutputs, Measure = "шт." },
                new LongSpecification { Name = "DVI-I Dual Link", Value = DVII_DualLinkOutputs, Measure = "шт." },
                new LongSpecification { Name = "USB Type-C", Value = USBTypeCOutputs, Measure = "шт." },
                new LongSpecification { Name = "VGA", Value = VGAOutputs, Measure = "шт." },
                new LongSpecification { Name = "VirtualLink", Value = VirtualLinkOutputs, Measure = "шт." },
                new LongSpecification { Name = "DVI-D Single Link", Value = DVIDSingleLinkOutputs, Measure = "шт." },
                new LongSpecification { Name = "Mini DisplayPort 2.1", Value = MiniDisplayPort2_1Outputs, Measure = "шт." },
                new LongSpecification { Name = "HDMI 2.0", Value = HDMI2_0Outputs, Measure = "шт." },
                new LongSpecification { Name = "DVI", Value = DVIOutputs, Measure = "шт." },
                new LongSpecification { Name = "Mini DisplayPort", Value = MiniDisplayPortOutputs, Measure = "шт." },
                new LongSpecification { Name = "HDMI 1.4", Value = HDMI1_4Outputs, Measure = "шт." },
                new LongSpecification { Name = "Mini DisplayPort 1.4a", Value = MiniDisplayPort1_4aOutputs, Measure = "шт." },
                new LongSpecification { Name = "Mini DisplayPort 1.4", Value = MiniDisplayPort1_4Outputs, Measure = "шт." },
                new LongSpecification { Name = "VHDCI", Value = VHDCIOutputs, Measure = "шт." },
                new LongSpecification { Name = "DVI-I Single Link", Value = DVII_SingleLinkOutputs, Measure = "шт." },
                new LongSpecification { Name = "S-Video", Value = SVideoOutputs, Measure = "шт." },
                new LongSpecification { Name = "Mini HDMI", Value = MiniHDMIOutputs, Measure = "шт." },
                new LongSpecification { Name = "DisplayPort 1.3", Value = DisplayPort1_3Outputs, Measure = "шт." },
                new LongSpecification { Name = "DVI-A", Value = DVIAOutputs, Measure = "шт." },
            };
            AddMetricsCategory(specifications, outputs);

            PCPartPickerContext context = new PCPartPickerContext();

            if (ExternalPowerIds != null)
            {
                List<string> externalPowerIds = ExternalPowerIds.Split(",").ToList();
                int index = 1;
                foreach (string id in externalPowerIds)
                {
                    GPUExternalPowerData entity = context.GPUExternalPowerDatas.Where(x => x.Id == Convert.ToInt32(id)).First();

                    List<LongSpecification> specification = new List<LongSpecification>
                    {
                        new LongSpecification { Name = $"Разъем дополнительного питания №{index}", LongSpecificationType = LongSpecificationType.Category },
                        new LongSpecification { Name = "Интерфейс", Value = entity.InterfaceName },
                        new LongSpecification { Name = "Количество интерфейсов", Value = entity.InterfaceCount },
                        new LongSpecification { Name = "Количество пинов", Value = entity.PinCount },
                    };

                    specifications.AddRange(specification);
                    index++;
                }
            }

            if (MultiInterfaceIds != null)
            {
                specifications.Add(new LongSpecification { Name = "SLI/CrossFire", LongSpecificationType = LongSpecificationType.Category });

                List<string> multiInterfaceIds = MultiInterfaceIds.Split(",").ToList();
                foreach (string id in multiInterfaceIds)
                {
                    GPUMultiInterfaceData entity = context.GPUMultiInterfaceDatas.Where(x => x.Id == Convert.ToInt32(id)).First();

                    List<LongSpecification> specification = new List<LongSpecification>
                    {
                        new LongSpecification { Name = "Технология", Value = entity.NameTechnology },
                        new LongSpecification { Name = "Количество интерфейсов", Value = entity.WaysCount }
                    };

                    specifications.AddRange(specification);
                }
            }

            List<LongSpecification> metrics = new()
            {
                new LongSpecification { Name = "Общие метрики", LongSpecificationType = LongSpecificationType.Category },
                new LongSpecification { Name = "Игровая метрика", Value = GamingPercentage, Measure = "%" },
                new LongSpecification { Name = "Стационарная метрика", Value = DesktopPercentage, Measure = "%" },
                new LongSpecification { Name = "Рабочая метрика", Value = WorkstationPercentage, Measure = "%" }
            };
            AddMetricsCategory(specifications, metrics);

            List<LongSpecification> perfomanceMetrics = new()
            {
                new LongSpecification { Name = "Метрики производительности", LongSpecificationType = LongSpecificationType.Category },
                new LongSpecification { Name = "3D Гейминг (Эффективная скорость)", Value = Effective3DGamingSpeed, Measure = "Pts" },
                new LongSpecification { Name = "Средняя локально-деформируемая ПРТ", Value = AvgLocallyDeformablePrt, Measure = "Pts" },
                new LongSpecification { Name = "Средняя освещенность с высокой динамикой", Value = AvgHighDynamicRangeLighting, Measure = "Pts" },
                new LongSpecification { Name = "Средний рендеринг массива графических шейдеров", Value = AvgRenderTargetArrayGShader, Measure = "Pts" },
                new LongSpecification { Name = "Средняя частица N-тела", Value = AvgNBodyParticleSystem, Measure = "Pts" },
                new LongSpecification { Name = "Локально-деформируемая ПРТ", Value = LocallyDeformablePrt, Measure = "Pts" },
                new LongSpecification { Name = "Освещенность с высокой динамикой", Value = HighDynamicRangeLighting, Measure = "Pts" },
                new LongSpecification { Name = "Рендеринг массива графических шейдеров", Value = RenderTargetArrayGShader, Measure = "Pts" },
                new LongSpecification { Name = "Частица N-тела", Value = NBodyParticleSystem, Measure = "Pts" },
                new LongSpecification { Name = "Параллакс-окклюзия-картирование", Value = ParallaxOcclusionMapping, Measure = "Pts" },
                new LongSpecification { Name = "Силовое сплетенное стадное поведение", Value = ForceSplattedFlocking, Measure = "Pts" },
                new LongSpecification { Name = "Среднее параллакс-окклюзия-картирование", Value = AvgParallaxOcclusionMapping, Measure = "Pts" },
                new LongSpecification { Name = "Среднее силовое сплетенное стадное поведение", Value = AvgForceSplattedFlocking, Measure = "Pts" },
            };
            AddMetricsCategory(specifications, perfomanceMetrics);

            return specifications;
        }
    }
}