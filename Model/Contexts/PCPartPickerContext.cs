using Microsoft.EntityFrameworkCore;
using PCConfig.Model.Converters;
using PCConfig.Model.PcPartPicker;
using PCConfig.Model.PcPartPicker.Entities;
using PCConfig.Model.PcPartPicker.Entities.Case;
using PCConfig.Model.PcPartPicker.Entities.CaseFan;
using PCConfig.Model.PcPartPicker.Entities.CPU;
using PCConfig.Model.PcPartPicker.Entities.CPUCooler;
using PCConfig.Model.PcPartPicker.Entities.GPU;
using PCConfig.Model.PcPartPicker.Entities.InternalDrive;
using PCConfig.Model.PcPartPicker.Entities.Memory;
using PCConfig.Model.PcPartPicker.Entities.Motherboard;
using PCConfig.Model.PcPartPicker.Entities.PowerSupply;
using PCConfig.Model.PcPartPicker.ShortViewData;
using System.Net.Sockets;

namespace PCConfig.Model.Contexts
{
    public class PCPartPickerContext : ApplicationContext
    {
        public DbSet<CpuCoolerResult> CpuCooler { get; set; }

        public DbSet<Part> Parts { get; set; } = null!;
        public DbSet<ImageData> Images { get; set; } = null!;
        public DbSet<ImageLink> ImageLinks { get; set; } = null!;
        public DbSet<PartNumber> PartNumbers { get; set; } = null!;
        public DbSet<PriceData> PriceDatas { get; set; } = null!;
        public DbSet<UserRating> UserRatings { get; set; } = null!;

        public DbSet<CaseData> CaseDatas { get; set; } = null!;
        public DbSet<CaseDriveBay> CaseDriveBays { get; set; } = null!;
        public DbSet<CaseExpansionSlot> CaseExpansionSlots { get; set; } = null!;
        public DbSet<CaseFrontPanelUSB> CaseFrontPanels { get; set; } = null!;
        public DbSet<CaseMotherboardFormFactor> CaseMotherboardFormFactors { get; set; } = null!;

        public DbSet<CaseFan> CaseFans { get; set; } = null!;
        public DbSet<CaseFanConnector> CaseFanConnectors { get; set; } = null!;
        public DbSet<CaseFanFeatures> CaseFanFeatures { get; set; } = null!;

        public DbSet<CPUCache> CPUCaches { get; set; } = null!;
        public DbSet<CPUCore> CPUCores { get; set; } = null!;
        public DbSet<CPUMainData> CPUMainDatas { get; set; } = null!;

        public DbSet<CPUCooler> CPUCoolers { get; set; } = null!;
        public DbSet<CPUCoolerSocket> CPUCoolerSockets { get; set; } = null!;

        public DbSet<GPUConnectData> GPUConnectDatas { get; set; } = null!;
        public DbSet<GPUExternalPowerData> GPUExternalPowerDatas { get; set; } = null!;
        public DbSet<GPUMainData> GPUMainDatas { get; set; } = null!;
        public DbSet<GPUMultiInterfaceData> GPUMultiInterfaceDatas { get; set; } = null!;
        public DbSet<GPUOutputsData> GPUOutputsDatas { get; set; } = null!;

        public DbSet<HDD> HDDs { get; set; } = null!;
        public DbSet<HybridStorage> HybridStorages { get; set; } = null!;
        public DbSet<SSD> SSDs { get; set; } = null!;

        public DbSet<MemoryCharacteristics> MemoryCharacteristics { get; set; } = null!;
        public DbSet<MemoryMainData> MemoryMainData { get; set; } = null!;

        public DbSet<MotherboardConnectData> MotherboardConnectDatas { get; set; } = null!;
        public DbSet<MotherboardEthernet> MotherboardEthernets { get; set; } = null!;
        public DbSet<MotherboardM2Slots> MotherboardM2Slots { get; set; } = null!;
        public DbSet<MotherboardMainData> MotherboardMainDatas { get; set; } = null!;
        public DbSet<MotherboardMemorySpeed> MotherboardMemorySpeeds { get; set; } = null!;
        public DbSet<MotherboardMultiInterface> MotherboardMultiInterfaces { get; set; } = null!;
        public DbSet<MotherboardSocket> MotherboardSockets { get; set; } = null!;

        public DbSet<PowerSupply> PowerSupplies { get; set; } = null!;
        public DbSet<PowerSupplyConnectors> PowerSupplyConnectors { get; set; } = null!;
        public DbSet<PowerSupplyEfficiency> PowerSupplyEfficiencies { get; set; } = null!;
        public DbSet<PowerSupplyOutput> PowerSupplyOutputs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            InitConnectionSettings("PcPartPickerConnectionSettings");

            optionsBuilder.UseMySql($"Host={ConnectionSettings.Host};Port={ConnectionSettings.Port};" +
                $"Database={ConnectionSettings.DatabaseName};Username={ConnectionSettings.Username};" +
                $"Password={ConnectionSettings.Password}",
                new MySqlServerVersion(new Version(8, 0, 34)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CpuCoolerResult>().HasNoKey();
        }

        public IEnumerable<PartShortData> GetPartsShortData(string partType)
        {
            IEnumerable<PartShortData> result = from p in Parts
                                                where p.PartType == partType
                                                join il in ImageLinks on p.Id equals il.PartId into ilGroup
                                                from il in ilGroup.DefaultIfEmpty()
                                                group new { p, il } by new { p.Id, p.Link, p.Name, p.Manufacturer, p.PartType, p.Key } into grouped
                                                select new PartShortData
                                                {
                                                    Part = new Part()
                                                    {
                                                        Id = grouped.Key.Id,
                                                        Name = grouped.Key.Name,
                                                        Manufacturer = grouped.Key.Manufacturer,
                                                        Link = grouped.Key.Link,
                                                        PartType = grouped.Key.PartType,
                                                        Key = grouped.Key.Key,
                                                    },
                                                    ImagesUrls = grouped.Select(x => x.il.Link).Where(x => x != null).ToList()
                                                };

            return result.ToList();
        }

        public IQueryable<PartShortData> GetCPUShortData()
        {
            var result = from p in Parts
                         where p.PartType == "cpu"

                         join cpu in CPUMainDatas on p.Id equals cpu.PartId into cpuGroup
                         from cpu in cpuGroup.DefaultIfEmpty()

                         join cpuCore in CPUCores on p.Id equals cpuCore.PartId into cpuCoreGroup
                         from cpuCore in cpuCoreGroup.DefaultIfEmpty()

                         join il in ImageLinks on p.Id equals il.PartId

                         group new { p, il, cpu, cpuCore } by new { p.Id, p.Link, p.Name, p.Manufacturer, p.PartType, p.Key } into grouped
                         select new PartShortData
                         {
                             Part = new Part()
                             {
                                 Id = grouped.Key.Id,
                                 Name = grouped.Key.Name,
                                 Manufacturer = grouped.Key.Manufacturer,
                                 Link = grouped.Key.Link,
                                 PartType = grouped.Key.PartType,
                                 Key = grouped.Key.Key,
                             },
                             ImagesUrls = grouped.Select(x => x.il.Link).Where(x => x != null).ToList(),
                             PartViewData = new CPUShortViewData()
                             {
                                 TDP = (int)grouped.Select(x => x.cpu.TDP).FirstOrDefault(),
                                 IncludesCooler = grouped.Select(x => x.cpu.IncludesCooler).FirstOrDefault(),
                                 CoreCount = (int)grouped.Select(x => x.cpuCore.CoreCount).FirstOrDefault(),
                                 PerformanceCoreClock = (double)grouped.Select(x => x.cpuCore.PerformanceCoreClock).FirstOrDefault(),
                                 PerformanceBoostClock = (double)grouped.Select(x => x.cpuCore.PerformanceBoostClock).FirstOrDefault(),
                                 Socket = grouped.Select(x => x.cpuCore.Socket).FirstOrDefault(),
                                 IntegratedGraphics = grouped.Select(x => x.cpuCore.IntegratedGraphics).FirstOrDefault(),
                             }
                         }
                         into intermediateResult
                         select new PartShortData
                         {
                             Part = intermediateResult.Part,
                             ImagesUrls = intermediateResult.ImagesUrls.Distinct(),
                             PartViewData = intermediateResult.PartViewData,
                             Specifications = intermediateResult.PartViewData.GetSpecificationList()
                         };

            return result;
        }

        public IQueryable<PartShortData> GetGPUShortData()
        {
            var result = from p in Parts
                         where p.PartType == "video-card"

                         join gpu in GPUMainDatas on p.Id equals gpu.PartId into gpuGroup
                         from gpu in gpuGroup.DefaultIfEmpty()

                         join il in ImageLinks on p.Id equals il.PartId

                         group new { p, il, gpu } by new { p.Id, p.Link, p.Name, p.Manufacturer, p.PartType, p.Key } into grouped
                         select new PartShortData
                         {
                             Part = new Part()
                             {
                                 Id = grouped.Key.Id,
                                 Name = grouped.Key.Name,
                                 Manufacturer = grouped.Key.Manufacturer,
                                 Link = grouped.Key.Link,
                                 PartType = grouped.Key.PartType,
                                 Key = grouped.Key.Key,
                             },
                             ImagesUrls = grouped.Select(x => x.il.Link).Where(x => x != null).ToList(),
                             PartViewData = new GPUShortViewData()
                             {
                                 Memory = (double)grouped.Select(x => x.gpu.Memory).FirstOrDefault(),
                                 MemoryType = grouped.Select(x => x.gpu.MemoryType).FirstOrDefault(),
                                 CoreClock = grouped.Select(x => x.gpu.CoreClock).FirstOrDefault()

                             }
                         }
                         into intermediateResult
                         select new PartShortData
                         {
                             Part = intermediateResult.Part,
                             ImagesUrls = intermediateResult.ImagesUrls.Distinct(),
                             PartViewData = intermediateResult.PartViewData,
                             Specifications = intermediateResult.PartViewData.GetSpecificationList()
                         };

            return result;
        }

        public IQueryable<PartShortData> GetRAMShortData()
        {
            var result = from p in Parts
                         where p.PartType == "memory"

                         join memory in MemoryCharacteristics on p.Id equals memory.PartId into memoryGroup
                         from memory in memoryGroup.DefaultIfEmpty()

                         join il in ImageLinks on p.Id equals il.PartId

                         group new { p, il, memory } by new { p.Id, p.Link, p.Name, p.Manufacturer, p.PartType, p.Key } into grouped
                         select new PartShortData
                         {
                             Part = new Part()
                             {
                                 Id = grouped.Key.Id,
                                 Name = grouped.Key.Name,
                                 Manufacturer = grouped.Key.Manufacturer,
                                 Link = grouped.Key.Link,
                                 PartType = grouped.Key.PartType,
                                 Key = grouped.Key.Key,
                             },
                             ImagesUrls = grouped.Select(x => x.il.Link).Where(x => x != null).ToList(),
                             PartViewData = new RAMShortViewData()
                             {
                                 MemorySpeed = grouped.Select(x => x.memory.MemorySpeed).FirstOrDefault(),
                                 MemoryType = grouped.Select(x => x.memory.MemoryType).FirstOrDefault(),
                                 ModulesCount = grouped.Select(x => x.memory.ModulesCount).FirstOrDefault(),
                                 ModulesMemory = grouped.Select(x => x.memory.ModulesMemory).FirstOrDefault(),
                                 ModulesMemoryMeasure = grouped.Select(x => x.memory.ModulesMemoryMeasure).FirstOrDefault(),

                                 Cas = grouped.Select(x => x.memory.Cas).FirstOrDefault(),
                                 Trcd = grouped.Select(x => x.memory.Trcd).FirstOrDefault(),
                                 Trp = grouped.Select(x => x.memory.Trp).FirstOrDefault(),
                                 Tras = grouped.Select(x => x.memory.Tras).FirstOrDefault(),
                             }
                         }
                         into intermediateResult
                         select new PartShortData
                         {
                             Part = intermediateResult.Part,
                             ImagesUrls = intermediateResult.ImagesUrls.Distinct(),
                             PartViewData = intermediateResult.PartViewData,
                             Specifications = intermediateResult.PartViewData.GetSpecificationList()
                         };

            return result;
        }

        public IQueryable<PartShortData> GetMotherboardShortData()
        {
            var result = from p in Parts
                         where p.PartType == "motherboard"

                         join motherboard in MotherboardMainDatas on p.Id equals motherboard.PartId
                         join socket in MotherboardSockets on p.Id equals socket.PartId
                         join connect in MotherboardConnectDatas on p.Id equals connect.PartId
                         join il in ImageLinks on p.Id equals il.PartId

                         group new { p, il, motherboard, socket, connect } by new
                         {
                             p.Id,
                             p.Link,
                             p.Name,
                             p.Manufacturer,
                             p.PartType,
                             p.Key
                         } into grouped
                         select new PartShortData
                         {
                             Part = new Part
                             {
                                 Id = grouped.Key.Id,
                                 Name = grouped.Key.Name,
                                 Manufacturer = grouped.Key.Manufacturer,
                                 Link = grouped.Key.Link,
                                 PartType = grouped.Key.PartType,
                                 Key = grouped.Key.Key,
                             },
                             ImagesUrls = grouped.Select(x => x.il.Link).Where(x => x != null).ToList(),
                             PartViewData = new MotherboardShortViewData
                             {
                                 FormFactor = grouped.Select(x => x.motherboard.FormFactor).FirstOrDefault(),
                                 Chipset = grouped.Select(x => x.motherboard.Chipset).FirstOrDefault(),
                                 MemorySlots = grouped.Select(x => x.motherboard.MemorySlots).FirstOrDefault(),
                                 MemoryType = grouped.Select(x => x.motherboard.MemoryType).FirstOrDefault(),
                                 PcieX16Slots = grouped.Select(x => x.connect.PcieX16Slots).FirstOrDefault(),
                                 Socket = grouped.Select(x => x.socket.SocketName).FirstOrDefault(),
                             }
                         }
                         into intermediateResult
                         select new PartShortData
                         {
                             Part = intermediateResult.Part,
                             ImagesUrls = intermediateResult.ImagesUrls.Distinct(),
                             PartViewData = intermediateResult.PartViewData,
                             Specifications = intermediateResult.PartViewData.GetSpecificationList()
                         };

            return result;
        }

        public IQueryable<PartShortData> GetPowerSupplyShortData()
        {
            var result = from p in Parts
                         where p.PartType == "power-supply"

                         join powerSupply in PowerSupplies on p.Id equals powerSupply.PartId
                         join connectors in PowerSupplyConnectors on p.Id equals connectors.PartId
                         join il in ImageLinks on p.Id equals il.PartId

                         group new { p, il, powerSupply, connectors } by new
                         {
                             p.Id,
                             p.Link,
                             p.Name,
                             p.Manufacturer,
                             p.PartType,
                             p.Key
                         }
                         into grouped
                         select new PartShortData
                         {
                             Part = new Part
                             {
                                 Id = grouped.Key.Id,
                                 Name = grouped.Key.Name,
                                 Manufacturer = grouped.Key.Manufacturer,
                                 Link = grouped.Key.Link,
                                 PartType = grouped.Key.PartType,
                                 Key = grouped.Key.Key,
                             },
                             ImagesUrls = grouped.Select(x => x.il.Link).Where(x => x != null).ToList(),
                             PartViewData = new PowerSupplyShortViewData
                             {
                                 Wattage = grouped.Select(x => x.powerSupply.Wattage).FirstOrDefault(),
                                 SATAConnectors = grouped.Select(x => x.connectors.SATAConnectors).FirstOrDefault(),
                                 PCIe62PinConnectors = grouped.Select(x => x.connectors.PCIe62PinConnectors).FirstOrDefault(),
                                 EPS8PinConnectors = grouped.Select(x => x.connectors.EPS8PinConnectors).FirstOrDefault(),
                                 Molex4PinConnectors = grouped.Select(x => x.connectors.Molex4PinConnectors).FirstOrDefault(),
                                 Type = grouped.Select(x => x.powerSupply.Type).FirstOrDefault(),
                             }
                         }
                         into intermediateResult
                         select new PartShortData
                         {
                             Part = intermediateResult.Part,
                             ImagesUrls = intermediateResult.ImagesUrls.Distinct(),
                             PartViewData = intermediateResult.PartViewData,
                             Specifications = intermediateResult.PartViewData.GetSpecificationList()
                         };

            return result;
        }

        public IQueryable<PartShortData> GetCaseShortData()
        {
            var result = from p in Parts
                         where p.PartType == "case"

                         join caseData in CaseDatas on p.Id equals caseData.PartId
                         join front in CaseFrontPanels on p.Id equals front.PartId
                         join il in ImageLinks on p.Id equals il.PartId

                         group new { p, il, caseData, front } by new
                         {
                             p.Id,
                             p.Link,
                             p.Name,
                             p.Manufacturer,
                             p.PartType,
                             p.Key
                         }
                         into grouped
                         select new PartShortData
                         {
                             Part = new Part
                             {
                                 Id = grouped.Key.Id,
                                 Name = grouped.Key.Name,
                                 Manufacturer = grouped.Key.Manufacturer,
                                 Link = grouped.Key.Link,
                                 PartType = grouped.Key.PartType,
                                 Key = grouped.Key.Key,
                             },
                             ImagesUrls = grouped.Select(x => x.il.Link).Where(x => x != null).ToList(),
                             PartViewData = new CaseShortViewData
                             {
                                 HasPowerSupply = grouped.Select(x => x.caseData.HasPowerSupply).FirstOrDefault(),
                                 Type = grouped.Select(x => x.caseData.Type).FirstOrDefault(),
                                 MaximumVideoCardLengthWith = grouped.Select(x => x.caseData.MaximumVideoCardLengthWith).FirstOrDefault(),
                                 FrontUSB = grouped.Select(x => x.front.Value).FirstOrDefault(),
                             }
                         }
                         into intermediateResult
                         select new PartShortData
                         {
                             Part = intermediateResult.Part,
                             ImagesUrls = intermediateResult.ImagesUrls.Distinct(),
                             PartViewData = intermediateResult.PartViewData,
                             Specifications = intermediateResult.PartViewData.GetSpecificationList()
                         };

            return result;
        }

        public IQueryable<PartShortData> GetCaseFanShortData()
        {
            var result = from p in Parts
                         where p.PartType == "case-fan"

                         join caseFan in CaseFans on p.Id equals caseFan.PartId
                         join il in ImageLinks on p.Id equals il.PartId

                         group new { p, il, caseFan } by new
                         {
                             p.Id,
                             p.Link,
                             p.Name,
                             p.Manufacturer,
                             p.PartType,
                             p.Key
                         }
                         into grouped
                         select new PartShortData
                         {
                             Part = new Part
                             {
                                 Id = grouped.Key.Id,
                                 Name = grouped.Key.Name,
                                 Manufacturer = grouped.Key.Manufacturer,
                                 Link = grouped.Key.Link,
                                 PartType = grouped.Key.PartType,
                                 Key = grouped.Key.Key,
                             },
                             ImagesUrls = grouped.Select(x => x.il.Link).Where(x => x != null).ToList(),
                             PartViewData = new CaseFanShortViewData
                             {
                                 Quantity = grouped.Select(x => x.caseFan.Quantity).FirstOrDefault(),
                                 Size = grouped.Select(x => x.caseFan.Size).FirstOrDefault(),
                                 MinRpm = grouped.Select(x => x.caseFan.MinRpm).FirstOrDefault(),
                                 MaxRpm = grouped.Select(x => x.caseFan.MaxRpm).FirstOrDefault(),
                                 MinNoiseLevel = grouped.Select(x => x.caseFan.MinNoiseLevel).FirstOrDefault(),
                                 MaxNoiseLevel = grouped.Select(x => x.caseFan.MaxNoiseLevel).FirstOrDefault(),
                             }
                         }
                         into intermediateResult
                         select new PartShortData
                         {
                             Part = intermediateResult.Part,
                             ImagesUrls = intermediateResult.ImagesUrls.Distinct(),
                             PartViewData = intermediateResult.PartViewData,
                             Specifications = intermediateResult.PartViewData.GetSpecificationList()
                         };

            return result;
        }

        public IQueryable<PartShortData> GetCPUCoolerShortData()
        {
            //var result = from p in Parts
            //             where p.PartType == "cpu-cooler"

            //             join cooler in CPUCoolers on p.Id equals cooler.PartId

            //             join il in ImageLinks on p.Id equals il.PartId

            //             join socket in CPUCoolerSockets on p.Id equals socket.PartId

            //             group new { p, il, cooler, socket } by new
            //             {
            //                 p.Id,
            //                 p.Link,
            //                 p.Name,
            //                 p.Manufacturer,
            //                 p.PartType,
            //                 p.Key
            //             }
            //             into grouped
            //             select new PartShortData
            //             {
            //                 Part = new Part
            //                 {
            //                     Id = grouped.Key.Id,
            //                     Name = grouped.Key.Name,
            //                     Manufacturer = grouped.Key.Manufacturer,
            //                     Link = grouped.Key.Link,
            //                     PartType = grouped.Key.PartType,
            //                     Key = grouped.Key.Key,
            //                 },
            //                 ImagesUrls = grouped.Select(x => x.il.Link).Where(x => x != null).ToList(),
            //                 PartViewData = new CPUCoolerShortViewData
            //                 {
            //                     MinRpm = grouped.Select(x => x.cooler.MinRpm).FirstOrDefault(),
            //                     MaxRpm = grouped.Select(x => x.cooler.MaxRpm).FirstOrDefault(),
            //                     MinNoiseLevel = grouped.Select(x => x.cooler.MinNoiseLevel).FirstOrDefault(),
            //                     MaxNoiseLevel = grouped.Select(x => x.cooler.MaxNoiseLevel).FirstOrDefault(),
            //                     Socket = grouped.Select(x => x.socket.Socket).FirstOrDefault()
            //                 }
            //             }
            //             into intermediateResult
            //             select new PartShortData
            //             {
            //                 Part = intermediateResult.Part,
            //                 ImagesUrls = intermediateResult.ImagesUrls.Distinct(),
            //                 PartViewData = intermediateResult.PartViewData,
            //                 Specifications = intermediateResult.PartViewData.GetSpecificationList()
            //             };

            var result = Set<CpuCoolerResult>().FromSqlRaw("CALL get_cpu_cooler()").ToList();
            result = result.ToList();

            return (IQueryable<PartShortData>)result.ToList();
        }

        public class CpuCoolerResult : PartViewData
        {
            public override IEnumerable<ShortSpecification> GetSpecificationList()
            {
                FanSizeConverter fanSizeConverter = new FanSizeConverter();

                var values = new List<ShortSpecification>
            {
                new ShortSpecification
                {
                    Name = "Сокет",
                    Value = Sockets
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

            public string ImageLinks { get; set; }

            public string PartNumbers { get; set; }

            public string Sockets { get; set; }

            public int Id { get; set; }

            public string? Name { get; set; }

            public string? Manufacturer { get; set; }

            public string? Link { get; set; }

            public double? MinRpm { get; set; }

            public double? MaxRpm { get; set; }

            public double? MinNoiseLevel { get; set; }

            public double? MaxNoiseLevel { get; set; }

            public IEnumerable<ShortSpecification> Specifications { get; set; }

            public PartViewData PartViewData { get; set; }

            public Part Part { get; set; }

            //public CpuCoolerResult()
            //{
            //    Specifications = GetSpecificationList();
            //    Part = new Part() { Id = Id, Link = Link, Manufacturer = Manufacturer, Name = Name };
            //}
        }

        public IQueryable<PartShortData> GetHDDShortData()
        {
            var result = from p in Parts
                         where p.PartType == "internal-hard-drive"

                         join hdd in HDDs on p.Id equals hdd.PartId
                         join il in ImageLinks on p.Id equals il.PartId

                         group new { p, il, hdd } by new
                         {
                             p.Id,
                             p.Link,
                             p.Name,
                             p.Manufacturer,
                             p.PartType,
                             p.Key
                         }
                         into grouped
                         select new PartShortData
                         {
                             Part = new Part
                             {
                                 Id = grouped.Key.Id,
                                 Name = grouped.Key.Name,
                                 Manufacturer = grouped.Key.Manufacturer,
                                 Link = grouped.Key.Link,
                                 PartType = grouped.Key.PartType,
                                 Key = grouped.Key.Key,
                             },
                             ImagesUrls = grouped.Select(x => x.il.Link).Where(x => x != null).ToList(),
                             PartViewData = new HDDShortViewData
                             {
                                 SpindleSpeed = grouped.Select(x => x.hdd.SpindleSpeed).FirstOrDefault(),
                                 Interface = grouped.Select(x => x.hdd.Interface).FirstOrDefault(),
                                 Cache = grouped.Select(x => x.hdd.Cache).FirstOrDefault(),
                                 CacheMeasure = grouped.Select(x => x.hdd.CacheMeasure).FirstOrDefault(),
                                 Capacity = grouped.Select(x => x.hdd.Capacity).FirstOrDefault(),
                                 CapacityMeasure = grouped.Select(x => x.hdd.CapacityMeasure).FirstOrDefault()
                             }
                         }
                         into intermediateResult
                         select new PartShortData
                         {
                             Part = intermediateResult.Part,
                             ImagesUrls = intermediateResult.ImagesUrls.Distinct(),
                             PartViewData = intermediateResult.PartViewData,
                             Specifications = intermediateResult.PartViewData.GetSpecificationList()
                         };

            return result;
        }

        public IQueryable<PartShortData> GetSSDShortData()
        {
            var result = from p in Parts
                         where p.PartType == "internal-hard-drive"

                         join ssd in SSDs on p.Id equals ssd.PartId
                         join il in ImageLinks on p.Id equals il.PartId

                         group new { p, il, ssd } by new
                         {
                             p.Id,
                             p.Link,
                             p.Name,
                             p.Manufacturer,
                             p.PartType,
                             p.Key
                         }
                         into grouped
                         select new PartShortData
                         {
                             Part = new Part
                             {
                                 Id = grouped.Key.Id,
                                 Name = grouped.Key.Name,
                                 Manufacturer = grouped.Key.Manufacturer,
                                 Link = grouped.Key.Link,
                                 PartType = grouped.Key.PartType,
                                 Key = grouped.Key.Key,
                             },
                             ImagesUrls = grouped.Select(x => x.il.Link).Where(x => x != null).ToList(),
                             PartViewData = new SSDShortViewData
                             {
                                 Interface = grouped.Select(x => x.ssd.Interface).FirstOrDefault(),
                                 Cache = grouped.Select(x => x.ssd.Cache).FirstOrDefault(),
                                 CacheMeasure = grouped.Select(x => x.ssd.CacheMeasure).FirstOrDefault(),
                                 Capacity = grouped.Select(x => x.ssd.Capacity).FirstOrDefault(),
                                 CapacityMeasure = grouped.Select(x => x.ssd.CapacityMeasure).FirstOrDefault()
                             }
                         }
                         into intermediateResult
                         select new PartShortData
                         {
                             Part = intermediateResult.Part,
                             ImagesUrls = intermediateResult.ImagesUrls.Distinct(),
                             PartViewData = intermediateResult.PartViewData,
                             Specifications = intermediateResult.PartViewData.GetSpecificationList()
                         };

            return result;
        }

        public IQueryable<PartShortData> GetHybridStorageShortData()
        {
            var result = from p in Parts
                         where p.PartType == "internal-hard-drive"

                         join hybrid in HybridStorages on p.Id equals hybrid.PartId
                         join il in ImageLinks on p.Id equals il.PartId

                         group new { p, il, hybrid } by new
                         {
                             p.Id,
                             p.Link,
                             p.Name,
                             p.Manufacturer,
                             p.PartType,
                             p.Key
                         }
                         into grouped
                         select new PartShortData
                         {
                             Part = new Part
                             {
                                 Id = grouped.Key.Id,
                                 Name = grouped.Key.Name,
                                 Manufacturer = grouped.Key.Manufacturer,
                                 Link = grouped.Key.Link,
                                 PartType = grouped.Key.PartType,
                                 Key = grouped.Key.Key,
                             },
                             ImagesUrls = grouped.Select(x => x.il.Link).Where(x => x != null).ToList(),
                             PartViewData = new HybridStorageShortViewData
                             {
                                 Interface = grouped.Select(x => x.hybrid.Interface).FirstOrDefault(),
                                 Cache = grouped.Select(x => x.hybrid.Cache).FirstOrDefault(),
                                 CacheMeasure = grouped.Select(x => x.hybrid.CacheMeasure).FirstOrDefault(),
                                 Capacity = grouped.Select(x => x.hybrid.Capacity).FirstOrDefault(),
                                 CapacityMeasure = grouped.Select(x => x.hybrid.CapacityMeasure).FirstOrDefault(),
                                 HybridSSDCache = grouped.Select(x => x.hybrid.HybridSSDCache).FirstOrDefault(),
                                 HybridSSDCacheMeasure = grouped.Select(x => x.hybrid.HybridSSDCacheMeasure).FirstOrDefault()
                             }
                         }
                         into intermediateResult
                         select new PartShortData
                         {
                             Part = intermediateResult.Part,
                             ImagesUrls = intermediateResult.ImagesUrls.Distinct(),
                             PartViewData = intermediateResult.PartViewData,
                             Specifications = intermediateResult.PartViewData.GetSpecificationList()
                         };

            return result;
        }


        public IQueryable<PartLongData> Get()
        {
            return null;
        }
    }
}
