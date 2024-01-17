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
using PCConfig.Model.PcPartPicker.ShortViewData;

namespace PCConfig.Model.Contexts
{
    public class PCPartPickerContext : ApplicationContext
    {
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
        }

        public IQueryable<PartShortData> GetCPUShortData()
        {
            var result = Set<CPUShortResult>().FromSqlRaw("CALL get_short_cpu()").ToList();

            IQueryable<PartShortData> parts = result.Select(g => new PartShortData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                Specifications = g.GetSpecificationList()
            }).AsQueryable();

            return parts;
        }

        public IQueryable<PartShortData> GetCPUCoolerShortData()
        {
            var result = Set<CPUCoolerShortResult>().FromSqlRaw("CALL get_short_cpu_cooler()").ToList();

            IQueryable<PartShortData> parts = result.Select(g => new PartShortData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                Specifications = g.GetSpecificationList()
            }).AsQueryable();

            return parts;
        }

        public IQueryable<PartShortData> GetGPUShortData()
        {
            var result = Set<GPUShortResult>().FromSqlRaw("CALL get_short_gpu()").ToList();

            IQueryable<PartShortData> parts = result.Select(g => new PartShortData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                Specifications = g.GetSpecificationList()
            }).AsQueryable();

            return parts;
        }

        public IQueryable<PartShortData> GetRAMShortData()
        {
            var result = Set<RAMShortResult>().FromSqlRaw("CALL get_short_ram()").ToList();

            IQueryable<PartShortData> parts = result.Select(g => new PartShortData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                Specifications = g.GetSpecificationList()
            }).AsQueryable();

            return parts;
        }

        public IQueryable<PartShortData> GetMotherboardShortData()
        {
            var result = Set<MotherboardShortResult>().FromSqlRaw("CALL get_short_motherboard()").ToList();

            IQueryable<PartShortData> parts = result.Select(g => new PartShortData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                Specifications = g.GetSpecificationList()
            }).AsQueryable();

            return parts;
        }

        public IQueryable<PartShortData> GetPowerSupplyShortData()
        {
            var result = Set<PowerSupplyShortResult>().FromSqlRaw("CALL get_short_power_supply()").ToList();

            IQueryable<PartShortData> parts = result.Select(g => new PartShortData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                Specifications = g.GetSpecificationList()
            }).AsQueryable();

            return parts;
        }

        public IQueryable<PartShortData> GetCaseShortData()
        {
            var result = Set<CaseShortResult>().FromSqlRaw("CALL get_short_case()").ToList();

            IQueryable<PartShortData> parts = result.Select(g => new PartShortData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                Specifications = g.GetSpecificationList()
            }).AsQueryable();

            return parts;
        }

        public IQueryable<PartShortData> GetCaseFanShortData()
        {
            var result = Set<CaseFanShortResult>().FromSqlRaw("CALL get_short_case_fan()").ToList();

            IQueryable<PartShortData> parts = result.Select(g => new PartShortData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                Specifications = g.GetSpecificationList()
            }).AsQueryable();

            return parts;
        }

        public IQueryable<PartShortData> GetHDDShortData()
        {
            var result = Set<HDDShortResult>().FromSqlRaw("CALL get_short_hdd()").ToList();

            IQueryable<PartShortData> parts = result.Select(g => new PartShortData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                Specifications = g.GetSpecificationList()
            }).AsQueryable();

            return parts;
        }

        public IQueryable<PartShortData> GetSSDShortData()
        {
            var result = Set<SSDShortResult>().FromSqlRaw("CALL get_short_ssd()").ToList();

            IQueryable<PartShortData> parts = result.Select(g => new PartShortData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                Specifications = g.GetSpecificationList()
            }).AsQueryable();

            return parts;
        }

        public IQueryable<PartShortData> GetHybridStorageShortData()
        {
            var result = Set<HybridStorageShortResult>().FromSqlRaw("CALL get_short_hybrid_storage()").ToList();

            IQueryable<PartShortData> parts = result.Select(g => new PartShortData
            {
                PartViewData = g,
                Part = new Part() { Id = g.Id, Link = g.Link, Manufacturer = g.Manufacturer, Name = g.Name },
                ImagesUrls = g.ImageLinks?.Split(",").ToList(),
                Specifications = g.GetSpecificationList()
            }).AsQueryable();

            return parts;
        }

        public IQueryable<PartLongData> Get()
        {
            return null;
        }
    }
}
