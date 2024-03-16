using PCConfig.Model.Contexts;
using PCConfig.Model.PcPartPicker;
using PCConfig.Model.UserBenchmark;
using PCConfig.ViewModel.SideMenu.Tabs.Realizations.GenerationModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PCConfig.Model.PcPartPicker.Entities.InternalDrive;

namespace PCConfig.Model.GeneratePC
{
    public class GenerateModel : INotifyPropertyChanged
    {
        public int SSDMemory { get; set; }
        public int HDDMemory { get; set; }

        public int WeightCPU { get; set; }
        public int WeightGPU { get; set; }
        public int WeightRAM { get; set; }
        public int WeightSSD { get; set; }
        public int WeightHDD { get; set; }
        public int WeightMotherboard { get; set; }
        public int WeightPowerSupply { get; set; }
        public int WeightCase { get; set; }
        public int WeightCaseFan { get; set; }

        public ObservableCollection<GameViewModel> Games { get; set; }

        public int MinFPS { get; set; }
        public int MaxFPS { get; set; }
        public int AverageFPS { get; set; }

        public Resolution Resolution { get; set; }
        public GameSettings GameSettings { get; set; }

        public int GameMetric { get; set; }
        public int DesktopMetric { get; set; }
        public int WorkstationMetric { get; set; }

        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public int AveragePrice { get; set; }

        public bool IsDNSProducts { get; set; }
        public bool IsCitilinkProducts { get; set; }
        public bool IsOnlyAvailableProducts { get; set; }

        public ObservableCollection<PartShortData> SelectedParts { get; set; }

        public int HDDCount { get; set; }
        public int SSDCount { get; set; }

        public bool IsGenerationCaseFan { get; set; }
        public bool IsPowerSupplyWithReserve { get; set; }
        public bool IsGenerationCase { get; set; }

        public int GenerationPCCount { get; set; }

        // now generate random PC
        public ObservableCollection<GeneratedPC> GeneratePC()
        {
            ObservableCollection<GeneratedPC> data = [];

            PCPartPickerContext context = new PCPartPickerContext();

            List<PartShortData> cpus = context.GetCPUShortData().Where(x => (x.DNSLink != null || x.CitilinkLink != null) && 
            (x.DesktopPercentage != null && x.WorkstationPercentage != null && x.GamingPercentage != null)).ToList();
            List<PartShortData> gpus = context.GetGPUShortData().Where(x => (x.DNSLink != null || x.CitilinkLink != null) &&
            (x.DesktopPercentage != null && x.WorkstationPercentage != null && x.GamingPercentage != null)).ToList();
            List<PartShortData> rams = context.GetRAMShortData().Where(x => (x.DNSLink != null || x.CitilinkLink != null) &&
            (x.DesktopPercentage != null && x.WorkstationPercentage != null && x.GamingPercentage != null)).ToList();
            List<PartShortData> ssds = context.GetSSDShortData().Where(x => (x.DNSLink != null || x.CitilinkLink != null) &&
            (x.DesktopPercentage != null && x.WorkstationPercentage != null && x.GamingPercentage != null)).ToList();
            List<PartShortData> hdds = context.GetHDDShortData().Where(x => (x.DNSLink != null || x.CitilinkLink != null) &&
            (x.DesktopPercentage != null && x.WorkstationPercentage != null && x.GamingPercentage != null)).ToList();

            List<PartShortData> motherboards = context.GetMotherboardShortData().Where(x => (x.DNSLink != null || x.CitilinkLink != null)).ToList();
            List<PartShortData> powerSupplys = context.GetPowerSupplyShortData().Where(x => (x.DNSLink != null || x.CitilinkLink != null)).ToList();

            List<PartShortData> cases = new();
            if (IsGenerationCase == true)
            {
                cases = context.GetCaseShortData().Where(x => (x.DNSLink != null || x.CitilinkLink != null)).ToList();
            }

            List<PartShortData> caseFans = new();
            if (IsGenerationCaseFan == true)
            {
                caseFans = context.GetCaseFanShortData().Where(x => (x.DNSLink != null || x.CitilinkLink != null)).ToList();
            }

            List<PartShortData> cpuCoolers = context.GetCPUCoolerShortData().Where(x => (x.DNSLink != null || x.CitilinkLink != null)).ToList();

            for (int i = 1; i < GenerationPCCount + 1; i++)
            {
                PartShortData cpu = GetHardware(cpus);
                PartShortData gpu = GetHardware(gpus);
                PartShortData ram = GetHardware(rams);
                PartShortData ssd = GetHardware(ssds);
                PartShortData hdd = GetHardware(hdds);

                PartShortData motherboard = GetHardware(motherboards);
                PartShortData powerSupply = GetHardware(powerSupplys);
                PartShortData case1 = GetHardware(cases);
                PartShortData caseFan = GetHardware(caseFans);
                PartShortData cpuCooler = GetHardware(cpuCoolers);

                ObservableCollection<PartShortData> parts1 = new ObservableCollection<PartShortData>();
                if (caseFan != null)
                {
                    parts1.Add(caseFan);
                }

                if (case1 != null)
                {
                    parts1.Add(case1);
                }

                parts1 = new ObservableCollection<PartShortData> { cpu, gpu, ram, ssd, hdd, motherboard, powerSupply, cpuCooler };

                GeneratedPC pc1 = new GeneratedPC()
                {
                    Parts = parts1,
                    IndexString = "Сборка " + i.ToString(),
                    Stats = GetPCStats(parts1)
                };

                data.Add(pc1);
            }

            return data;
        }

        public GeneratedPCStats GetPCStats(ObservableCollection<PartShortData> parts)
        {
            PCPartPickerContext context = new PCPartPickerContext();

            GeneratedPCStats stats = new GeneratedPCStats();
            int? price = 0;
            int? hdd = 0;
            int? ssd = 0;

            foreach (PartShortData part in parts)
            {
                int pricePart = 0;

                if (part.CitilinkPrice.Price != null)
                {
                    pricePart += (int)part.CitilinkPrice.Price;
                }

                if (part.DNSPrice.Price != null)
                {
                    pricePart += (int)part.DNSPrice.Price;
                }

                if (part.CitilinkPrice.Price != null && part.DNSPrice.Price != null)
                {
                    pricePart /= 2;
                }

                price += pricePart;

                if (part.Part.PartType == "hdd")
                {
                    HDD entity = context.HDDs.Where(x => x.PartId == part.Part.Id).First();

                    if (entity.CapacityMeasure == "GB")
                    {
                        hdd += (int)entity.Capacity;
                    } 
                    else if (entity.CapacityMeasure == "TB")
                    {
                        hdd += (int)entity.Capacity * 1024;
                    }

                    continue;
                }

                if (part.Part.PartType == "ssd")
                {
                    SSD entity = context.SSDs.Where(x => x.PartId == part.Part.Id).First();

                    if (entity.CapacityMeasure == "GB")
                    {
                        ssd += (int)entity.Capacity;
                    }
                    else if (entity.CapacityMeasure == "TB")
                    {
                        ssd += (int)entity.Capacity * 1024;
                    }

                    continue;
                }
            }

            return new GeneratedPCStats() { Price = (int)price, HDD = (int)hdd, SSD = (int)ssd };
        }

        #region INotifyPropertyChanged Implementation

        public PartShortData GetHardware(List<PartShortData> parts)
        {
            if (parts.Count > 0)
            {
                Random random = new Random();
                int randomIndex = random.Next(0, parts.Count);
                return parts[randomIndex];
            }
            else
            {
                return null;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}