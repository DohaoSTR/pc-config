using Microsoft.EntityFrameworkCore;
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
using PCConfig.Model.PcPartPicker.LongResult;
using PCConfig.Model.PcPartPicker.PriceResults;
using PCConfig.Model.PcPartPicker.ShortViewData;
using PCConfig.Model.Prices.Citilink;
using PCConfig.Model.Prices.DNS;

namespace PCConfig.Model.Contexts
{
    public class PCPartPickerContext : ApplicationContext
    {
        public DbSet<DNSAvailableResult> DNSAvailables { get; set; }
        public DbSet<DNSPriceResult> DNSPrices { get; set; }
        public DbSet<CitilinkAvailableResult> CitilinkAvailables { get; set; }
        public DbSet<CitilinkPriceResult> CitilinkPrices { get; set; }

        public DbSet<CPULongResult> CPULongData { get; set; }
        public DbSet<GPULongResult> GPULongData { get; set; }
        public DbSet<CPUCoolerLongResult> CPUCoolerLongData { get; set; }
        public DbSet<MotherboardLongResult> MotherboardLongResult { get; set; }
        public DbSet<RAMLongResult> RAMLongResult { get; set; }
        public DbSet<CaseFanLongResult> CaseFanLongResult { get; set; }
        public DbSet<CaseLongResult> CaseLongResult { get; set; }
        public DbSet<PowerSupplyLongResult> PowerSupplyLongResult { get; set; }
        public DbSet<SSDLongResult> SSDLongResult { get; set; }
        public DbSet<HDDLongResult> HDDLongResult { get; set; }
        public DbSet<HybridStorageLongResult> HybridStorageLongResult { get; set; }

        public DbSet<CPUShortResult> CPUShortData { get; set; }
        public DbSet<GPUShortResult> GPUShortData { get; set; }
        public DbSet<RAMShortResult> RAMShortData { get; set; }
        public DbSet<MotherboardShortResult> MotherboardShortData { get; set; }
        public DbSet<SSDShortResult> SSDShortData { get; set; }
        public DbSet<HDDShortResult> HDDShortData { get; set; }
        public DbSet<PowerSupplyShortResult> PowerSupplyShortData { get; set; }
        public DbSet<CPUCoolerShortResult> CPUCoolerShortData { get; set; }
        public DbSet<HybridStorageShortResult> HybridStorageShortData { get; set; }
        public DbSet<CaseFanShortResult> CaseFanShortData { get; set; }
        public DbSet<CaseShortResult> CaseShortData { get; set; }

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
            modelBuilder.Entity<CPUCoolerShortResult>().HasNoKey();

            modelBuilder.Entity<DNSAvailableResult>().HasNoKey();
            modelBuilder.Entity<DNSPriceResult>().HasNoKey();
            modelBuilder.Entity<CitilinkPriceResult>().HasNoKey();
            modelBuilder.Entity<CitilinkAvailableResult>().HasNoKey();
        }

        public IQueryable<PartShortData> GetCPUShortData()
        {
            var result = Set<CPUShortResult>().FromSqlRaw($"CALL get_short_cpu('{App.CityName}')").ToList();

            IQueryable<PartShortData> parts = result.Select(g => new PartShortData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name, PartType = g.PartType },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                Specifications = g.GetSpecificationList(),

                DNSAvailable = new DNSAvailable()
                {
                    CityName = App.CityName,
                    DateTime = g.DNSAvailDateTime,
                    DeliveryInfo = g.DNSDeilveryInfo,
                    Status = g.DNSStatus
                },
                DNSPrice = new DNSPrice() { DateTime = g.DNSPriceDateTime, Price = g.DNSPrice },

                CitilinkAvailable = new CitilinkAvailable() { CityName = App.CityName, DateTime = g.CitilinkAvailDateTime, IsAvailable = g.CitilinkIsAvailable },
                CitilinkPrice = new CitilinkPrice() { DateTime = g.CitilinkPriceDateTime, Price = g.CitilinkPrice },

                DNSLink = g.DNSLink,
                CitilinkLink = g.CitilinkLink,

                GamingPercentage = g.GamingPercentage,
                DesktopPercentage = g.DesktopPercentage,
                WorkstationPercentage = g.WorkstationPercentage
            }).AsQueryable();

            return parts;
        }

        public IQueryable<PartShortData> GetCPUCoolerShortData()
        {
            var result = Set<CPUCoolerShortResult>().FromSqlRaw($"CALL get_short_cpu_cooler('{App.CityName}')").ToList();

            IQueryable<PartShortData> parts = result.Select(g => new PartShortData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name, PartType = g.PartType },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                Specifications = g.GetSpecificationList(),

                DNSAvailable = new DNSAvailable()
                {
                    CityName = App.CityName,
                    DateTime = g.DNSAvailDateTime,
                    DeliveryInfo = g.DNSDeilveryInfo,
                    Status = g.DNSStatus
                },
                DNSPrice = new DNSPrice() { DateTime = g.DNSPriceDateTime, Price = g.DNSPrice },

                CitilinkAvailable = new CitilinkAvailable() { CityName = App.CityName, DateTime = g.CitilinkAvailDateTime, IsAvailable = g.CitilinkIsAvailable },
                CitilinkPrice = new CitilinkPrice() { DateTime = g.CitilinkPriceDateTime, Price = g.CitilinkPrice },

                DNSLink = g.DNSLink,
                CitilinkLink = g.CitilinkLink
            }).AsQueryable();

            return parts;
        }

        public IQueryable<PartShortData> GetGPUShortData()
        {
            var result = Set<GPUShortResult>().FromSqlRaw($"CALL get_short_gpu('{App.CityName}')").ToList();

            IQueryable<PartShortData> parts = result.Select(g => new PartShortData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name, PartType = g.PartType },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                Specifications = g.GetSpecificationList(),

                DNSAvailable = new DNSAvailable()
                {
                    CityName = App.CityName,
                    DateTime = g.DNSAvailDateTime,
                    DeliveryInfo = g.DNSDeilveryInfo,
                    Status = g.DNSStatus
                },
                DNSPrice = new DNSPrice() { DateTime = g.DNSPriceDateTime, Price = g.DNSPrice },

                CitilinkAvailable = new CitilinkAvailable() { CityName = App.CityName, DateTime = g.CitilinkAvailDateTime, IsAvailable = g.CitilinkIsAvailable },
                CitilinkPrice = new CitilinkPrice() { DateTime = g.CitilinkPriceDateTime, Price = g.CitilinkPrice },

                DNSLink = g.DNSLink,
                CitilinkLink = g.CitilinkLink,

                GamingPercentage = g.GamingPercentage,
                DesktopPercentage = g.DesktopPercentage,
                WorkstationPercentage = g.WorkstationPercentage
            }).AsQueryable();

            return parts;
        }

        public IQueryable<PartShortData> GetRAMShortData()
        {
            var result = Set<RAMShortResult>().FromSqlRaw($"CALL get_short_ram('{App.CityName}')").ToList();

            IQueryable<PartShortData> parts = result.Select(g => new PartShortData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name, PartType = g.PartType },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                Specifications = g.GetSpecificationList(),

                DNSAvailable = new DNSAvailable()
                {
                    CityName = App.CityName,
                    DateTime = g.DNSAvailDateTime,
                    DeliveryInfo = g.DNSDeilveryInfo,
                    Status = g.DNSStatus
                },
                DNSPrice = new DNSPrice() { DateTime = g.DNSPriceDateTime, Price = g.DNSPrice },

                CitilinkAvailable = new CitilinkAvailable() { CityName = App.CityName, DateTime = g.CitilinkAvailDateTime, IsAvailable = g.CitilinkIsAvailable },
                CitilinkPrice = new CitilinkPrice() { DateTime = g.CitilinkPriceDateTime, Price = g.CitilinkPrice },

                DNSLink = g.DNSLink,
                CitilinkLink = g.CitilinkLink,

                GamingPercentage = g.GamingPercentage,
                DesktopPercentage = g.DesktopPercentage,
                WorkstationPercentage = g.WorkstationPercentage
            }).AsQueryable();

            return parts;
        }

        public IQueryable<PartShortData> GetMotherboardShortData()
        {
            var result = Set<MotherboardShortResult>().FromSqlRaw($"CALL get_short_motherboard('{App.CityName}')").ToList();

            IQueryable<PartShortData> parts = result.Select(g => new PartShortData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name, PartType = g.PartType },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                Specifications = g.GetSpecificationList(),

                DNSAvailable = new DNSAvailable()
                {
                    CityName = App.CityName,
                    DateTime = g.DNSAvailDateTime,
                    DeliveryInfo = g.DNSDeilveryInfo,
                    Status = g.DNSStatus
                },
                DNSPrice = new DNSPrice() { DateTime = g.DNSPriceDateTime, Price = g.DNSPrice },

                CitilinkAvailable = new CitilinkAvailable() { CityName = App.CityName, DateTime = g.CitilinkAvailDateTime, IsAvailable = g.CitilinkIsAvailable },
                CitilinkPrice = new CitilinkPrice() { DateTime = g.CitilinkPriceDateTime, Price = g.CitilinkPrice },

                DNSLink = g.DNSLink,
                CitilinkLink = g.CitilinkLink
            }).AsQueryable();

            return parts;
        }

        public IQueryable<PartShortData> GetPowerSupplyShortData()
        {
            var result = Set<PowerSupplyShortResult>().FromSqlRaw($"CALL get_short_power_supply('{App.CityName}')").ToList();

            IQueryable<PartShortData> parts = result.Select(g => new PartShortData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name, PartType = g.PartType },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                Specifications = g.GetSpecificationList(),

                DNSAvailable = new DNSAvailable()
                {
                    CityName = App.CityName,
                    DateTime = g.DNSAvailDateTime,
                    DeliveryInfo = g.DNSDeilveryInfo,
                    Status = g.DNSStatus
                },
                DNSPrice = new DNSPrice() { DateTime = g.DNSPriceDateTime, Price = g.DNSPrice },

                CitilinkAvailable = new CitilinkAvailable() { CityName = App.CityName, DateTime = g.CitilinkAvailDateTime, IsAvailable = g.CitilinkIsAvailable },
                CitilinkPrice = new CitilinkPrice() { DateTime = g.CitilinkPriceDateTime, Price = g.CitilinkPrice },

                DNSLink = g.DNSLink,
                CitilinkLink = g.CitilinkLink,
            }).AsQueryable();

            return parts;
        }

        public IQueryable<PartShortData> GetCaseShortData()
        {
            var result = Set<CaseShortResult>().FromSqlRaw($"CALL get_short_case('{App.CityName}')").ToList();

            IQueryable<PartShortData> parts = result.Select(g => new PartShortData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name, PartType = g.PartType },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                Specifications = g.GetSpecificationList(),

                DNSAvailable = new DNSAvailable()
                {
                    CityName = App.CityName,
                    DateTime = g.DNSAvailDateTime,
                    DeliveryInfo = g.DNSDeilveryInfo,
                    Status = g.DNSStatus
                },
                DNSPrice = new DNSPrice() { DateTime = g.DNSPriceDateTime, Price = g.DNSPrice },

                CitilinkAvailable = new CitilinkAvailable() { CityName = App.CityName, DateTime = g.CitilinkAvailDateTime, IsAvailable = g.CitilinkIsAvailable },
                CitilinkPrice = new CitilinkPrice() { DateTime = g.CitilinkPriceDateTime, Price = g.CitilinkPrice },

                DNSLink = g.DNSLink,
                CitilinkLink = g.CitilinkLink
            }).AsQueryable();

            return parts;
        }

        public IQueryable<PartShortData> GetCaseFanShortData()
        {
            var result = Set<CaseFanShortResult>().FromSqlRaw($"CALL get_short_case_fan('{App.CityName}')").ToList();

            IQueryable<PartShortData> parts = result.Select(g => new PartShortData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name, PartType = g.PartType },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                Specifications = g.GetSpecificationList(),

                DNSAvailable = new DNSAvailable()
                {
                    CityName = App.CityName,
                    DateTime = g.DNSAvailDateTime,
                    DeliveryInfo = g.DNSDeilveryInfo,
                    Status = g.DNSStatus
                },
                DNSPrice = new DNSPrice() { DateTime = g.DNSPriceDateTime, Price = g.DNSPrice },

                CitilinkAvailable = new CitilinkAvailable() { CityName = App.CityName, DateTime = g.CitilinkAvailDateTime, IsAvailable = g.CitilinkIsAvailable },
                CitilinkPrice = new CitilinkPrice() { DateTime = g.CitilinkPriceDateTime, Price = g.CitilinkPrice },

                DNSLink = g.DNSLink,
                CitilinkLink = g.CitilinkLink,
            }).AsQueryable();

            return parts;
        }

        public IQueryable<PartShortData> GetHDDShortData()
        {
            var result = Set<HDDShortResult>().FromSqlRaw($"CALL get_short_hdd('{App.CityName}')").ToList();

            IQueryable<PartShortData> parts = result.Select(g => new PartShortData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name, PartType = "hdd" },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                Specifications = g.GetSpecificationList(),

                DNSAvailable = new DNSAvailable()
                {
                    CityName = App.CityName,
                    DateTime = g.DNSAvailDateTime,
                    DeliveryInfo = g.DNSDeilveryInfo,
                    Status = g.DNSStatus
                },
                DNSPrice = new DNSPrice() { DateTime = g.DNSPriceDateTime, Price = g.DNSPrice },

                CitilinkAvailable = new CitilinkAvailable() { CityName = App.CityName, DateTime = g.CitilinkAvailDateTime, IsAvailable = g.CitilinkIsAvailable },
                CitilinkPrice = new CitilinkPrice() { DateTime = g.CitilinkPriceDateTime, Price = g.CitilinkPrice },

                DNSLink = g.DNSLink,
                CitilinkLink = g.CitilinkLink,

                GamingPercentage = g.GamingPercentage,
                DesktopPercentage = g.DesktopPercentage,
                WorkstationPercentage = g.WorkstationPercentage
            }).AsQueryable();

            return parts;
        }

        public IQueryable<PartShortData> GetSSDShortData()
        {
            var result = Set<SSDShortResult>().FromSqlRaw($"CALL get_short_ssd('{App.CityName}')").ToList();

            IQueryable<PartShortData> parts = result.Select(g => new PartShortData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name, PartType = "ssd" },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                Specifications = g.GetSpecificationList(),

                DNSAvailable = new DNSAvailable()
                {
                    CityName = App.CityName,
                    DateTime = g.DNSAvailDateTime,
                    DeliveryInfo = g.DNSDeilveryInfo,
                    Status = g.DNSStatus
                },
                DNSPrice = new DNSPrice() { DateTime = g.DNSPriceDateTime, Price = g.DNSPrice },

                CitilinkAvailable = new CitilinkAvailable() { CityName = App.CityName, DateTime = g.CitilinkAvailDateTime, IsAvailable = g.CitilinkIsAvailable },
                CitilinkPrice = new CitilinkPrice() { DateTime = g.CitilinkPriceDateTime, Price = g.CitilinkPrice },

                DNSLink = g.DNSLink,
                CitilinkLink = g.CitilinkLink,

                GamingPercentage = g.GamingPercentage,
                DesktopPercentage = g.DesktopPercentage,
                WorkstationPercentage = g.WorkstationPercentage
            }).AsQueryable();

            return parts;
        }

        public IQueryable<PartShortData> GetHybridStorageShortData()
        {
            var result = Set<HybridStorageShortResult>().FromSqlRaw($"CALL get_short_hybrid_storage('{App.CityName}')").ToList();

            IQueryable<PartShortData> parts = result.Select(g => new PartShortData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name, PartType = g.PartType },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                Specifications = g.GetSpecificationList(),

                DNSAvailable = new DNSAvailable()
                {
                    CityName = App.CityName,
                    DateTime = g.DNSAvailDateTime,
                    DeliveryInfo = g.DNSDeilveryInfo,
                    Status = g.DNSStatus
                },
                DNSPrice = new DNSPrice() { DateTime = g.DNSPriceDateTime, Price = g.DNSPrice },

                CitilinkAvailable = new CitilinkAvailable() { CityName = App.CityName, DateTime = g.CitilinkAvailDateTime, IsAvailable = g.CitilinkIsAvailable },
                CitilinkPrice = new CitilinkPrice() { DateTime = g.CitilinkPriceDateTime, Price = g.CitilinkPrice },

                DNSLink = g.DNSLink,
                CitilinkLink = g.CitilinkLink,

                GamingPercentage = g.GamingPercentage,
                DesktopPercentage = g.DesktopPercentage,
                WorkstationPercentage = g.WorkstationPercentage

            }).AsQueryable();

            return parts;
        }

        //
        public List<CitilinkAvailableResult> GetCitilinkAvailable(int id)
        {
            List<CitilinkAvailableResult> result1 = Set<CitilinkAvailableResult>().FromSqlRaw($"CALL get_most_actual_citilink_available('{id}');").ToList();

            return result1;
        }

        public CitilinkPriceResult GetCitilinkPrice(int id)
        {
            var result2 = Set<CitilinkPriceResult>().FromSqlRaw($"CALL get_most_actual_citilink_price('{id}');").ToList().FirstOrDefault();

            return result2;
        }

        public string GetCitilinkLink(int id)
        {
            PricesContext pricesContext = new PricesContext();
            CitilinkProduct result2 = pricesContext.CitilinkProducts.Where(x => x.Id == id).First();

            return result2.Link;
        }
        //


        //
        public List<DNSAvailableResult> GetDNSAvailable(string uid)
        {
            var result1 = Set<DNSAvailableResult>().FromSqlRaw($"CALL get_most_actual_dns_available('{uid}');").ToList();

            return result1;
        }

        public DNSPriceResult GetDNSPrice(string uid)
        {
            var result2 = Set<DNSPriceResult>().FromSqlRaw($"CALL get_most_actual_dns_price('{uid}');").ToList().FirstOrDefault();

            return result2;
        }

        public string GetDNSLink(string uid)
        {
            PricesContext pricesContext = new PricesContext();
            DNSProduct result2 = pricesContext.DNSProducts.Where(x => x.UID == uid).First();

            return result2.Link;
        }

        //
        public PartLongData GetCPULongData(int partId)
        {
            var result = Set<CPULongResult>().FromSqlRaw($"CALL get_long_cpu('{partId}');").ToList();

            PartLongData part = result.Select(g => new PartLongData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                PartNumbers = g.PartNumbers?.Split(",").ToList(),
                Specifications = g.GetSpecificationList()
            }).First();

            if (part.PartViewData.DNSUid != null)
            {
                part.DNSAvailables = GetDNSAvailable(part.PartViewData.DNSUid);
                part.DNSPrice = GetDNSPrice(part.PartViewData.DNSUid);
                part.DNSLink = GetDNSLink(part.PartViewData.DNSUid);
            }

            if (part.PartViewData.CitilinkId != null)
            {
                part.CitilinkAvailables = GetCitilinkAvailable((int)part.PartViewData.CitilinkId);
                part.CitilinkPrice = GetCitilinkPrice((int)part.PartViewData.CitilinkId);
                part.CitilinkLink = GetCitilinkLink((int)part.PartViewData.CitilinkId);
            }

            return part;
        }

        public PartLongData GetGPULongData(int partId)
        {
            var result = Set<GPULongResult>().FromSqlRaw($"CALL get_long_gpu('{partId}');").ToList();

            PartLongData part = result.Select(g => new PartLongData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                PartNumbers = g.PartNumbers?.Split(",").ToList(),
                Specifications = g.GetSpecificationList()
            }).First();

            if (part.PartViewData.DNSUid != null)
            {
                part.DNSAvailables = GetDNSAvailable(part.PartViewData.DNSUid);
                part.DNSPrice = GetDNSPrice(part.PartViewData.DNSUid);
                part.DNSLink = GetDNSLink(part.PartViewData.DNSUid);
            }

            if (part.PartViewData.CitilinkId != null)
            {
                part.CitilinkAvailables = GetCitilinkAvailable((int)part.PartViewData.CitilinkId);
                part.CitilinkPrice = GetCitilinkPrice((int)part.PartViewData.CitilinkId);
                part.CitilinkLink = GetCitilinkLink((int)part.PartViewData.CitilinkId);
            }

            return part;
        }

        public PartLongData GetRAMLongData(int partId)
        {
            var result = Set<RAMLongResult>().FromSqlRaw($"CALL get_long_ram('{partId}');").ToList();

            PartLongData part = result.Select(g => new PartLongData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                PartNumbers = g.PartNumbers?.Split(",").ToList(),
                Specifications = g.GetSpecificationList()
            }).First();

            if (part.PartViewData.DNSUid != null)
            {
                part.DNSAvailables = GetDNSAvailable(part.PartViewData.DNSUid);
                part.DNSPrice = GetDNSPrice(part.PartViewData.DNSUid);
                part.DNSLink = GetDNSLink(part.PartViewData.DNSUid);
            }

            if (part.PartViewData.CitilinkId != null)
            {
                part.CitilinkAvailables = GetCitilinkAvailable((int)part.PartViewData.CitilinkId);
                part.CitilinkPrice = GetCitilinkPrice((int)part.PartViewData.CitilinkId);
                part.CitilinkLink = GetCitilinkLink((int)part.PartViewData.CitilinkId);
            }

            return part;
        }

        public PartLongData GetSSDLongData(int partId)
        {
            var result = Set<SSDLongResult>().FromSqlRaw($"CALL get_long_ssd('{partId}');").ToList();

            PartLongData part = result.Select(g => new PartLongData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                PartNumbers = g.PartNumbers?.Split(",").ToList(),
                Specifications = g.GetSpecificationList()
            }).First();

            if (part.PartViewData.DNSUid != null)
            {
                part.DNSAvailables = GetDNSAvailable(part.PartViewData.DNSUid);
                part.DNSPrice = GetDNSPrice(part.PartViewData.DNSUid);
                part.DNSLink = GetDNSLink(part.PartViewData.DNSUid);
            }

            if (part.PartViewData.CitilinkId != null)
            {
                part.CitilinkAvailables = GetCitilinkAvailable((int)part.PartViewData.CitilinkId);
                part.CitilinkPrice = GetCitilinkPrice((int)part.PartViewData.CitilinkId);
                part.CitilinkLink = GetCitilinkLink((int)part.PartViewData.CitilinkId);
            }

            return part;
        }

        public PartLongData GetHDDLongData(int partId)
        {
            var result = Set<HDDLongResult>().FromSqlRaw($"CALL get_long_hdd('{partId}');").ToList();

            PartLongData part = result.Select(g => new PartLongData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                PartNumbers = g.PartNumbers?.Split(",").ToList(),
                Specifications = g.GetSpecificationList()
            }).First();

            if (part.PartViewData.DNSUid != null)
            {
                part.DNSAvailables = GetDNSAvailable(part.PartViewData.DNSUid);
                part.DNSPrice = GetDNSPrice(part.PartViewData.DNSUid);
                part.DNSLink = GetDNSLink(part.PartViewData.DNSUid);
            }

            if (part.PartViewData.CitilinkId != null)
            {
                part.CitilinkAvailables = GetCitilinkAvailable((int)part.PartViewData.CitilinkId);
                part.CitilinkPrice = GetCitilinkPrice((int)part.PartViewData.CitilinkId);
                part.CitilinkLink = GetCitilinkLink((int)part.PartViewData.CitilinkId);
            }

            return part;
        }

        public PartLongData GetHybridStorageLongData(int partId)
        {
            var result = Set<HybridStorageLongResult>().FromSqlRaw($"CALL get_long_hybrid_storage('{partId}');").ToList();

            PartLongData part = result.Select(g => new PartLongData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                PartNumbers = g.PartNumbers?.Split(",").ToList(),
                Specifications = g.GetSpecificationList()
            }).First();

            if (part.PartViewData.DNSUid != null)
            {
                part.DNSAvailables = GetDNSAvailable(part.PartViewData.DNSUid);
                part.DNSPrice = GetDNSPrice(part.PartViewData.DNSUid);
                part.DNSLink = GetDNSLink(part.PartViewData.DNSUid);
            }

            if (part.PartViewData.CitilinkId != null)
            {
                part.CitilinkAvailables = GetCitilinkAvailable((int)part.PartViewData.CitilinkId);
                part.CitilinkPrice = GetCitilinkPrice((int)part.PartViewData.CitilinkId);
                part.CitilinkLink = GetCitilinkLink((int)part.PartViewData.CitilinkId);
            }

            return part;
        }

        public PartLongData GetMotherboardLongData(int partId)
        {
            var result = Set<MotherboardLongResult>().FromSqlRaw($"CALL get_long_motherboard('{partId}');").ToList();

            PartLongData part = result.Select(g => new PartLongData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                PartNumbers = g.PartNumbers?.Split(",").ToList(),
                Specifications = g.GetSpecificationList()
            }).First();

            if (part.PartViewData.DNSUid != null)
            {
                part.DNSAvailables = GetDNSAvailable(part.PartViewData.DNSUid);
                part.DNSPrice = GetDNSPrice(part.PartViewData.DNSUid);
                part.DNSLink = GetDNSLink(part.PartViewData.DNSUid);
            }

            if (part.PartViewData.CitilinkId != null)
            {
                part.CitilinkAvailables = GetCitilinkAvailable((int)part.PartViewData.CitilinkId);
                part.CitilinkPrice = GetCitilinkPrice((int)part.PartViewData.CitilinkId);
                part.CitilinkLink = GetCitilinkLink((int)part.PartViewData.CitilinkId);
            }

            return part;
        }

        public PartLongData GetCaseLongData(int partId)
        {
            var result = Set<CaseLongResult>().FromSqlRaw($"CALL get_long_case('{partId}');").ToList();

            PartLongData part = result.Select(g => new PartLongData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                PartNumbers = g.PartNumbers?.Split(",").ToList(),
                Specifications = g.GetSpecificationList()
            }).First();

            if (part.PartViewData.DNSUid != null)
            {
                part.DNSAvailables = GetDNSAvailable(part.PartViewData.DNSUid);
                part.DNSPrice = GetDNSPrice(part.PartViewData.DNSUid);
                part.DNSLink = GetDNSLink(part.PartViewData.DNSUid);
            }

            if (part.PartViewData.CitilinkId != null)
            {
                part.CitilinkAvailables = GetCitilinkAvailable((int)part.PartViewData.CitilinkId);
                part.CitilinkPrice = GetCitilinkPrice((int)part.PartViewData.CitilinkId);
                part.CitilinkLink = GetCitilinkLink((int)part.PartViewData.CitilinkId);
            }

            return part;
        }

        public PartLongData GetCaseFanLongData(int partId)
        {
            var result = Set<CaseFanLongResult>().FromSqlRaw($"CALL get_long_case_fan('{partId}');").ToList();

            PartLongData part = result.Select(g => new PartLongData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                PartNumbers = g.PartNumbers?.Split(",").ToList(),
                Specifications = g.GetSpecificationList()
            }).First();

            if (part.PartViewData.DNSUid != null)
            {
                part.DNSAvailables = GetDNSAvailable(part.PartViewData.DNSUid);
                part.DNSPrice = GetDNSPrice(part.PartViewData.DNSUid);
                part.DNSLink = GetDNSLink(part.PartViewData.DNSUid);
            }

            if (part.PartViewData.CitilinkId != null)
            {
                part.CitilinkAvailables = GetCitilinkAvailable((int)part.PartViewData.CitilinkId);
                part.CitilinkPrice = GetCitilinkPrice((int)part.PartViewData.CitilinkId);
                part.CitilinkLink = GetCitilinkLink((int)part.PartViewData.CitilinkId);
            }

            return part;
        }

        public PartLongData GetPowerSupplyLongData(int partId)
        {
            var result = Set<PowerSupplyLongResult>().FromSqlRaw($"CALL get_long_power_supply('{partId}');").ToList();

            PartLongData part = result.Select(g => new PartLongData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                PartNumbers = g.PartNumbers?.Split(",").ToList(),
                Specifications = g.GetSpecificationList()
            }).First();

            if (part.PartViewData.DNSUid != null)
            {
                part.DNSAvailables = GetDNSAvailable(part.PartViewData.DNSUid);
                part.DNSPrice = GetDNSPrice(part.PartViewData.DNSUid);
                part.DNSLink = GetDNSLink(part.PartViewData.DNSUid);
            }

            if (part.PartViewData.CitilinkId != null)
            {
                part.CitilinkAvailables = GetCitilinkAvailable((int)part.PartViewData.CitilinkId);
                part.CitilinkPrice = GetCitilinkPrice((int)part.PartViewData.CitilinkId);
                part.CitilinkLink = GetCitilinkLink((int)part.PartViewData.CitilinkId);
            }

            return part;
        }

        public PartLongData GetCPUCoolerLongData(int partId)
        {
            var result = Set<CPUCoolerLongResult>().FromSqlRaw($"CALL get_long_cpu_cooler('{partId}');").ToList();

            PartLongData part = result.Select(g => new PartLongData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                PartNumbers = g.PartNumbers?.Split(",").ToList(),
                Specifications = g.GetSpecificationList()
            }).First();

            if (part.PartViewData.DNSUid != null)
            {
                part.DNSAvailables = GetDNSAvailable(part.PartViewData.DNSUid);
                part.DNSPrice = GetDNSPrice(part.PartViewData.DNSUid);
                part.DNSLink = GetDNSLink(part.PartViewData.DNSUid);
            }

            if (part.PartViewData.CitilinkId != null)
            {
                part.CitilinkAvailables = GetCitilinkAvailable((int)part.PartViewData.CitilinkId);
                part.CitilinkPrice = GetCitilinkPrice((int)part.PartViewData.CitilinkId);
                part.CitilinkLink = GetCitilinkLink((int)part.PartViewData.CitilinkId);
            }

            return part;
        }
    }
}
