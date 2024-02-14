using GalaSoft.MvvmLight.Command;
using PCConfig.Model.Contexts;
using PCConfig.Model.GeneratePC;
using PCConfig.Model.PcPartPicker;
using PCConfig.Model.UserBenchmark;
using PCConfig.Model.UserBenchmark.Entities;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace PCConfig.ViewModel.SideMenu.Tabs.Realizations.GenerationModel
{
    // до 10 ssd
    // до 10 hdd
    // до 10 охлаждений
    // до 10 оперативных плашек
    // до 2 видеокарт
    public class GenerationViewModel : INotifyPropertyChanged
    {
        public GenerateModel GenerateModel { get; set; }

        private PCPartPickerContext _pppContext;
        private UserBenchmarkContext _ubContext;

        private ObservableCollection<string> _availableTypes;
        public ObservableCollection<string> AvailableTypes
        {
            get
            {
                return _availableTypes;
            }
            set
            {
                _availableTypes = value;
                OnPropertyChanged(nameof(AvailableTypes));
            }
        }

        public void SetSelectionPartViewDatas(IQueryable<PartShortData> datas)
        {
            ChoisedTypeParts = new ObservableCollection<SelectionPartViewData>();

            int index = 1;
            foreach (PartShortData data in datas.ToList())
            {
                ChoisedTypeParts.Add(new SelectionPartViewData() { PartShortData = data, Index = index });
                index++;
            }
            OnPropertyChanged(nameof(ChoisedTypeParts));
        }

        private string _selectedTypePart;
        public string SelectedTypePart
        {
            get
            {
                return _selectedTypePart;
            }
            set
            {
                _selectedTypePart = value;
                OnPropertyChanged(nameof(SelectedTypePart));

                switch (SelectedTypePart)
                {
                    case "Процессор":
                        SetSelectionPartViewDatas(_pppContext.GetCPUShortData());
                        break;
                    case "Кулер для процессора":
                        SetSelectionPartViewDatas(_pppContext.GetCPUCoolerShortData());
                        break;
                    case "Видеокарта":
                        SetSelectionPartViewDatas(_pppContext.GetGPUShortData());
                        break;
                    case "Оперативная память":
                        SetSelectionPartViewDatas(_pppContext.GetRAMShortData());
                        break;
                    case "Материнская плата":
                        SetSelectionPartViewDatas(_pppContext.GetMotherboardShortData());
                        break;
                    case "HDD":
                        SetSelectionPartViewDatas(_pppContext.GetHDDShortData());
                        break;
                    case "SSD":
                        SetSelectionPartViewDatas(_pppContext.GetSSDShortData());
                        break;
                    case "Блок питания":
                        SetSelectionPartViewDatas(_pppContext.GetPowerSupplyShortData());
                        break;
                    case "Охлаждение компьютера":
                        SetSelectionPartViewDatas(_pppContext.GetCaseFanShortData());
                        break;
                    case "Корпус":
                        SetSelectionPartViewDatas(_pppContext.GetCaseShortData());
                        break;
                    default:
                        break;
                }

                SelectedPart = ChoisedTypeParts[0];
            }
        }

        private ObservableCollection<SelectionPartViewData> _choisedTypeParts;
        public ObservableCollection<SelectionPartViewData> ChoisedTypeParts
        {
            get
            {
                return _choisedTypeParts;
            }
            set
            {
                _choisedTypeParts = value;
                OnPropertyChanged(nameof(ChoisedTypeParts));
            }
        }

        private SelectionPartViewData _selectedPart;
        public SelectionPartViewData SelectedPart
        {
            get
            {
                return _selectedPart;
            }
            set
            {
                _selectedPart = value;
                OnPropertyChanged(nameof(SelectedPart));
            }
        }

        public Resolution[] ResolutionValues { get; set; }
        public GameSettings[] GameSettingValues { get; set; }

        private ObservableCollection<GeneratedPC> _generatedParts;
        public ObservableCollection<GeneratedPC> GeneratedParts
        {
            get
            {
                return _generatedParts;
            }
            set
            {
                _generatedParts = value;
                OnPropertyChanged(nameof(GeneratedParts));
            }
        }

        public GenerationViewModel()
        {
            _pppContext = new PCPartPickerContext();
            _ubContext = new UserBenchmarkContext();

            GenerateModel = new GenerateModel();

            GenerateModel.WeightCPU = 100;
            GenerateModel.WeightGPU = 100;
            GenerateModel.WeightRAM = 100;

            GenerateModel.WeightSSD = 75;
            GenerateModel.WeightHDD = 75;
            GenerateModel.WeightMotherboard = 100;

            GenerateModel.WeightPowerSupply = 75;
            GenerateModel.WeightCase = 50;
            GenerateModel.WeightCaseFan = 50;

            GenerateModel.GameMetric = 75;
            GenerateModel.DesktopMetric = 100;
            GenerateModel.WorkstationMetric = 75;

            GenerateModel.AveragePrice = 40000;
            GenerateModel.MinPrice = 15000;
            GenerateModel.MaxPrice = 60000;

            GenerateModel.AverageFPS = 70;
            GenerateModel.MinFPS = 40;
            GenerateModel.MaxFPS = 100;

            GenerateModel.HDDCount = 1;
            GenerateModel.SSDCount = 1;

            GenerateModel.SSDMemory = 512;
            GenerateModel.HDDMemory = 1024;

            GenerateModel.IsOnlyAvailableProducts = false;
            GenerateModel.IsDNSProducts = true;
            GenerateModel.IsCitilinkProducts = true;

            GenerateModel.GenerationPCCount = 1;

            GenerateModel.IsGenerationCase = true;
            GenerateModel.IsGenerationCaseFan = false;
            GenerateModel.IsPowerSupplyWithReserve = true;

            ResolutionValues = Enum.GetValues(typeof(Resolution)).Cast<Resolution>().ToArray();
            GenerateModel.Resolution = ResolutionValues[1];

            GameSettingValues = Enum.GetValues(typeof(GameSettings)).Cast<GameSettings>().ToArray();
            GenerateModel.GameSettings = GameSettingValues[1];

            IEnumerable<Game> games = _ubContext.GetGames();
            GenerateModel.Games = new ObservableCollection<GameViewModel>();
            foreach (Game game in games)
            {
                GenerateModel.Games.Add(new GameViewModel(game.Name, true));
            }

            AvailableTypes = new ObservableCollection<string>()
            {
                "Процессор",
                "Кулер для процессора",
                "Видеокарта",
                "Оперативная память",
                "Материнская плата",
                "HDD",
                "SSD",
                "Блок питания",
                "Охлаждение компьютера",
                "Корпус"
            };
            SelectedTypePart = AvailableTypes[0];
            GenerateModel.SelectedParts = new ObservableCollection<PartShortData>();
        }

        public ICommand AddPartCommand => new RelayCommand(AddPart, () => (GenerateModel.SelectedParts.Any(x => x.Part.PartType == SelectedPart.PartShortData.Part.PartType) == false) && SelectedPart != null);

        private void AddPart()
        {
            GenerateModel.SelectedParts.Add(SelectedPart.PartShortData);
            OnPropertyChanged(nameof(GenerateModel.SelectedParts));
        }

        public ICommand RemovePartCommand => new RelayCommand<PartShortData>(RemovePart);

        private void RemovePart(PartShortData part)
        {
            GenerateModel.SelectedParts.Remove(part);
            OnPropertyChanged(nameof(GenerateModel.SelectedParts));
        }

        private RelayCommand _selectAllGamesCommand;
        public RelayCommand SelectAllGamesCommand
        {
            get
            {
                return _selectAllGamesCommand ?? (_selectAllGamesCommand = new RelayCommand(
                    () =>
                    {
                        foreach (var game in GenerateModel.Games)
                        {
                            game.IsSelected = true;
                        }
                    }));
            }
        }

        private RelayCommand _clearSelectionGamesCommand;
        public RelayCommand ClearSelectionGamesCommand
        {
            get
            {
                return _clearSelectionGamesCommand ?? (_clearSelectionGamesCommand = new RelayCommand(
                    () =>
                    {
                        foreach (var game in GenerateModel.Games)
                        {
                            game.IsSelected = false;
                        }
                    }));
            }
        }

        private Visibility _gamesPanelVisibility = Visibility.Visible;
        public Visibility GamesPanelVisibility
        {
            get { return _gamesPanelVisibility; }
            set
            {
                if (_gamesPanelVisibility != value)
                {
                    _gamesPanelVisibility = value;
                    OnPropertyChanged(nameof(GamesPanelVisibility));
                }
            }
        }

        private string _gamePanelIconKind = "MenuUp";
        public string GamePanelIconKind
        {
            get { return _gamePanelIconKind; }
            set
            {
                if (_gamePanelIconKind != value)
                {
                    _gamePanelIconKind = value;
                    OnPropertyChanged(nameof(GamePanelIconKind));
                }
            }
        }

        public ICommand ToggleGamesPanelVisibilityCommand => new RelayCommand(ChangeGamePanelVisibility);

        public void ChangeGamePanelVisibility()
        {
            GamesPanelVisibility = GamesPanelVisibility == Visibility.Visible
                ? Visibility.Collapsed
            : Visibility.Visible;

            GamePanelIconKind = GamePanelIconKind == "MenuUp"
                ? "MenuDown"
                : "MenuUp";
        }

        private Visibility _settingsPanelVisibility = Visibility.Visible;
        public Visibility SettingsPanelVisibility
        {
            get { return _settingsPanelVisibility; }
            set
            {
                if (_settingsPanelVisibility != value)
                {
                    _settingsPanelVisibility = value;
                    OnPropertyChanged(nameof(SettingsPanelVisibility));
                }
            }
        }

        private string _settingsPanelIconKind = "MenuUp";
        public string SettingsPanelIconKind
        {
            get { return _settingsPanelIconKind; }
            set
            {
                if (_settingsPanelIconKind != value)
                {
                    _settingsPanelIconKind = value;
                    OnPropertyChanged(nameof(SettingsPanelIconKind));
                }
            }
        }

        public ICommand ChangeSettingsPanelVisibilityCommand => new RelayCommand(ChangeSettingsPanelVisibility);

        public void ChangeSettingsPanelVisibility()
        {
            SettingsPanelVisibility = SettingsPanelVisibility == Visibility.Visible
                ? Visibility.Collapsed
                : Visibility.Visible;

            SettingsPanelIconKind = SettingsPanelIconKind == "MenuUp"
                ? "MenuDown"
                : "MenuUp";
        }

        public ICommand GeneratePCCommand => new RelayCommand(GeneratePC);

        public void GeneratePC()
        {
            GeneratedParts = GenerateModel.GeneratePC();
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