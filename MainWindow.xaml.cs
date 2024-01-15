using PCConfig.View;
using PCConfig.View.Tabs;
using PCConfig.View.Tabs.Products;
using PCConfig.ViewModel;
using PCConfig.ViewModel.SideMenu;
using PCConfig.ViewModel.SideMenu.Tabs;
using PCConfig.ViewModel.SideMenu.Tabs.Realizations.Products;
using PCConfig.ViewModel.SideMenu.Tabs.Strategies;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PCConfig
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<ISideMenuItem, ITabStrategy?> _tabStrategies;
        private Dictionary<ISideMenuItem, ITabStrategy?> _parts;

        private readonly int _userId;

        public MainWindow(int userId)
        {
            InitializeComponent();

            _userId = userId;

            InitializeTabStrategies();

            MainWindowViewModel model = new(_tabStrategies.Keys);
            model.ExitButtonClicked += Model_ExitButtonClicked;
            DataContext = model;
        }

        private void InitializeTabStrategies()
        {
            CPUTabStrategy cpuStrategy = new CPUTabStrategy();
            cpuStrategy.ProductItemClicked += ProductItemControl_Clicked;

            CPUCoolerTabStrategy cpuCoolerStrategy = new CPUCoolerTabStrategy();
            cpuCoolerStrategy.ProductItemClicked += ProductItemControl_Clicked;

            GPUTabStrategy gpuStrategy = new GPUTabStrategy();
            gpuStrategy.ProductItemClicked += ProductItemControl_Clicked;

            RAMTabStrategy ramStrategy = new RAMTabStrategy();
            ramStrategy.ProductItemClicked += ProductItemControl_Clicked;

            MotherboardTabStrategy motherboardStrategy = new MotherboardTabStrategy();
            motherboardStrategy.ProductItemClicked += ProductItemControl_Clicked;

            SSDTabStrategy ssdStrategy = new SSDTabStrategy();
            ssdStrategy.ProductItemClicked += ProductItemControl_Clicked;

            HDDTabStrategy hddStrategy = new HDDTabStrategy();
            hddStrategy.ProductItemClicked += ProductItemControl_Clicked;

            HybridStorageTabStrategy hybridStrategy = new HybridStorageTabStrategy();
            hybridStrategy.ProductItemClicked += ProductItemControl_Clicked;

            PowerSupplyTabStrategy powerSupplyStrategy = new PowerSupplyTabStrategy();
            powerSupplyStrategy.ProductItemClicked += ProductItemControl_Clicked;

            CaseFanTabStrategy caseFanStrategy = new CaseFanTabStrategy();
            caseFanStrategy.ProductItemClicked += ProductItemControl_Clicked;

            CaseTabStrategy caseStrategy = new CaseTabStrategy();
            caseStrategy.ProductItemClicked += ProductItemControl_Clicked;

            Dictionary<ISideMenuItem, ITabStrategy?> parts = new() {
                { new SideMenuItemViewModel("Процессоры", "Memory", SideMenuItemLocationType.Top), cpuStrategy },
                { new SideMenuItemViewModel("Кулеры для процессоров", "CeilingFan",SideMenuItemLocationType.Top), cpuCoolerStrategy },
                { new SideMenuItemViewModel("Видеокарты", "ExpansionCard", SideMenuItemLocationType.Top), gpuStrategy },
                { new SideMenuItemViewModel("Оперативная память", "Ruler", SideMenuItemLocationType.Top), ramStrategy },
                { new SideMenuItemViewModel("Материнские платы", "Chip", SideMenuItemLocationType.Top), motherboardStrategy },
                { new SideMenuItemViewModel("Твердотельные накопители (SSD)", "Nas", SideMenuItemLocationType.Top), ssdStrategy },
                { new SideMenuItemViewModel("Жесткие диски (HDD)", "Harddisk", SideMenuItemLocationType.Top), hddStrategy },
                { new SideMenuItemViewModel("Гибридные накопители", "Server", SideMenuItemLocationType.Top), hybridStrategy },
                { new SideMenuItemViewModel("Блоки питания", "PowerSocket", SideMenuItemLocationType.Top), powerSupplyStrategy },
                { new SideMenuItemViewModel("Охлаждение компьютера", "Fan", SideMenuItemLocationType.Top), caseFanStrategy },
                { new SideMenuItemViewModel("Корпуса", "DesktopTower", SideMenuItemLocationType.Top), caseStrategy }
            };

            _parts = parts;

            AccountSettingsTabStrategy accountStrategy = new(_userId);
            accountStrategy.ChangePassword += AccountStrategy_ChangePassword;

            GameDataTabStrategy gameDataStrategy = new();
            gameDataStrategy.Backed += GameDataStrategy_Backed;
            gameDataStrategy.Clicked += GameDataStrategy_Clicked;

            _tabStrategies = new Dictionary<ISideMenuItem, ITabStrategy?>
            {
                { new DropOutSideMenuItemViewModel("Комплектующие", "Grid", parts.Keys, SideMenuItemLocationType.Top), null },
                { new SideMenuItemViewModel("Игровые данные", "ControllerClassic", SideMenuItemLocationType.Top), gameDataStrategy },
                { new SideMenuItemViewModel("Аналитика рынка", "Poll", SideMenuItemLocationType.Top), new GenerationAssemblyTabStrategy() },
                { new SideMenuItemViewModel("Конфигуратор", "Layers", SideMenuItemLocationType.Top), new ConfiguratorTabStrategy() },
                { new SideMenuItemViewModel("Генерация сборки", "Cogs", SideMenuItemLocationType.Top), new GenerationAssemblyTabStrategy() },
                { new SideMenuItemViewModel("Настройки аккаунта", "AccountBox", SideMenuItemLocationType.Bottom, true), accountStrategy }
            };

            Item_IsSelectedPropertyChanged(_tabStrategies.Keys.Last(), null);

            foreach (ISideMenuItem item in _tabStrategies.Keys)
            {
                Type type = item.GetType();

                if (type == typeof(SideMenuItemViewModel))
                {
                    SideMenuItemViewModel viewModel = (SideMenuItemViewModel)item;
                    viewModel.IsSelectedPropertyChanged += Item_IsSelectedPropertyChanged;
                }

                if (type == typeof(DropOutSideMenuItemViewModel))
                {
                    DropOutSideMenuItemViewModel viewModel = (DropOutSideMenuItemViewModel)item;
                    foreach (SideMenuItemViewModel sideMenuItem in viewModel.SideMenuItems)
                    {
                        sideMenuItem.IsSelectedPropertyChanged += Item_IsSelectedPropertyChanged;
                    }
                }
            }
        }

        private void ProductItemControl_Clicked(ProductsListItemViewModel model)
        {
            ProductItemControl control = new();
            control.Backed += ProductItemControl_Backed;

            MainSectionGrid.Children.Clear();
            MainSectionGrid.Children.Add(control);
        }

        private void ProductItemControl_Backed()
        {
            //ISideMenuItem foundKey = FindKeyByValueType(_tabStrategies, typeof(GameDataTabStrategy));
            //Item_IsSelectedPropertyChanged(foundKey, null);
        }

        private void GameDataStrategy_Clicked(string gameName, int samples, string imageUrl)
        {
            GameDataControl control = new(gameName, samples, imageUrl);
            control.Backed += GameDataStrategy_Backed;

            MainSectionGrid.Children.Clear();
            MainSectionGrid.Children.Add(control);
        }

        private static ISideMenuItem FindKeyByValueType(Dictionary<ISideMenuItem, ITabStrategy?> dictionary, Type targetType)
        {
            KeyValuePair<ISideMenuItem, ITabStrategy?> foundItem = dictionary.FirstOrDefault(pair => pair.Value?.GetType() == targetType);
            return foundItem.Key;
        }

        private void GameDataStrategy_Backed()
        {
            ISideMenuItem foundKey = FindKeyByValueType(_tabStrategies, typeof(GameDataTabStrategy));
            Item_IsSelectedPropertyChanged(foundKey, null);
        }

        private void AccountStrategy_ChangePassword(string email)
        {
            ChangePasswordTabControl control = new(_userId, email);
            control.BackButtonClicked += Control_BackButtonClicked;
            control.PasswordChangeProccedureExecute += Control_PasswordChangeProccedureExecute;

            MainSectionGrid.Children.Clear();
            MainSectionGrid.Children.Add(control);
        }

        private void Control_PasswordChangeProccedureExecute()
        {
            Item_IsSelectedPropertyChanged(_tabStrategies.Keys.Last(), null);
        }

        private void Control_BackButtonClicked()
        {
            Item_IsSelectedPropertyChanged(_tabStrategies.Keys.Last(), null);
        }

        private void Model_ExitButtonClicked()
        {
            AccessWindow window = new();
            window.Show();

            Close();
        }

        private ITabStrategy? GetStrategy(ISideMenuItem item)
        {
            _tabStrategies.TryGetValue(item, out ITabStrategy? strategy);

            if (strategy == null)
            {
                foreach (ISideMenuItem key in _tabStrategies.Keys)
                {
                    Type type = key.GetType();

                    if (type == typeof(DropOutSideMenuItemViewModel))
                    {
                        DropOutSideMenuItemViewModel viewModel = (DropOutSideMenuItemViewModel)key;
                        foreach (SideMenuItemViewModel sideMenuItem in viewModel.SideMenuItems)
                        {
                            if (sideMenuItem == item)
                            {
                                return _parts[sideMenuItem];
                            }
                        }
                    }
                }
            }
            else
            {
                return strategy;
            }

            return null;
        }

        private void Item_IsSelectedPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            ISideMenuItem item = (ISideMenuItem)sender;
            Type type = item.GetType();

            ITabStrategy? strategy = GetStrategy(item);
            if (type == typeof(SideMenuItemViewModel) && strategy != null && item.IsSelected == true)
            {
                Control control = strategy.HandleTab((SideMenuItemViewModel)item);

                MainSectionGrid.Children.Clear();
                MainSectionGrid.Children.Add(control);
            }
        }

        private void ToggleMenu(object sender, RoutedEventArgs e)
        {
            if (MenuColumn.Width.Value == CollapseButtonColumn.ActualWidth)
            {
                MenuColumn.SetValue(ColumnDefinition.WidthProperty, new GridLength(0, GridUnitType.Auto));

                TabsControl.Visibility = Visibility.Visible;
            }
            else
            {
                MenuColumn.SetValue(ColumnDefinition.WidthProperty, new GridLength(CollapseButtonColumn.ActualWidth));

                TabsControl.Visibility = Visibility.Collapsed;
            }
        }

        private void UserControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                e.Handled = true;
            }
        }
    }
}