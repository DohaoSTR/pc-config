using PCConfig.Model.Contexts;
using PCConfig.Model.PcPartPicker;
using PCConfig.Model.UserBenchmark;
using PCConfig.ViewModel.SideMenu.Tabs.Realizations.GenerationModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using PCConfig.Model.PcPartPicker.Entities.InternalDrive;

namespace PCConfig.Model.GeneratePC
{
    public class GenerateModel : INotifyPropertyChanged
    {
        public int SSDMemory { get; set; }
        public int HDDMemory { get; set; }

        public int WeightCPUMetric { get; set; }
        public int WeightGPUMetric { get; set; }
        public int WeightRAMMetric { get; set; }
        public int WeightSSDMetric { get; set; }
        public int WeightHDDMetric { get; set; }

        public int WeightCPUPrice { get; set; }
        public int WeightGPUPrice { get; set; }
        public int WeightRAMPrice { get; set; }
        public int WeightSSDPrice { get; set; }
        public int WeightHDDPrice { get; set; }

        public int WeightMotherboardPrice { get; set; }
        public int WeightPowerSupplyPrice { get; set; }
        public int WeightCasePrice { get; set; }
        public int WeightCaseFanPrice { get; set; }

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
        public bool IsUpgrade { get; set; }

        public int GenerationPCCount { get; set; }

        public ObservableCollection<GeneratedPC> GeneratePC()
        {
            ObservableCollection<GeneratedPC> data = [];

            PCPartPickerContext context = new PCPartPickerContext();
            PartShortData cpu1 = context.GetCPUShortData().ToList()[113];
            PartShortData gpu1 = context.GetGPUShortData().ToList()[193];
            PartShortData motherboard1 = context.GetMotherboardShortData().ToList()[14];
            PartShortData ram1 = context.GetRAMShortData().ToList()[37];
            PartShortData powerSupply1 = context.GetPowerSupplyShortData().ToList()[7];
            PartShortData case1 = context.GetCaseShortData().ToList()[1];
            PartShortData ssd1 = context.GetSSDShortData().ToList()[38];
            PartShortData hdd1 = context.GetHDDShortData().ToList()[226];
            PartShortData cpuCooler1 = context.GetCPUCoolerShortData().ToList()[10];
            ObservableCollection<PartShortData> parts1 = new ObservableCollection<PartShortData> { cpu1, gpu1, ram1, ssd1, hdd1, motherboard1, powerSupply1, case1, cpuCooler1 };

            GeneratedPC pc1 = new GeneratedPC() 
            { 
                Parts = parts1,
                IndexString = "Сборка 1",
                Stats = GetPCStats(parts1)
            };

            data.Add(pc1);

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}