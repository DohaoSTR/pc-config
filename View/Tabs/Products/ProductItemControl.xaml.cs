using PCConfig.Model.Contexts;
using PCConfig.Model.PcPartPicker;
using PCConfig.ViewModel.SideMenu.Tabs.Realizations.Products;
using PCConfig.ViewModel.SideMenu.Tabs.Strategies;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PCConfig.View.Tabs.Products
{
    /// <summary>
    /// Interaction logic for ProductItemControl.xaml
    /// </summary>
    public partial class ProductItemControl : UserControl
    {
        public event Action<Type> Backed;

        private Type _tabType;

        public ProductItemControl(Type tabType, int productId)
        {
            InitializeComponent();

            _tabType = tabType;

            PCPartPickerContext context = new PCPartPickerContext();

            PartLongData partLongDatas = null;
            if (tabType == typeof(CPUTabStrategy))
            {
                partLongDatas = context.GetCPULongData(productId);
            }
            else if (tabType == typeof(CPUCoolerTabStrategy))
            {
                partLongDatas = context.GetCPUCoolerLongData(productId);
            }
            else if (tabType == typeof(SSDTabStrategy))
            {
                partLongDatas = context.GetSSDLongData(productId);
            }
            else if (tabType == typeof(HDDTabStrategy))
            {
                partLongDatas = context.GetHDDLongData(productId);
            }
            else if (tabType == typeof(PowerSupplyTabStrategy))
            {
                partLongDatas = context.GetPowerSupplyLongData(productId);
            }
            else if (tabType == typeof(MotherboardTabStrategy))
            {
                partLongDatas = context.GetMotherboardLongData(productId);
            }
            else if (tabType == typeof(RAMTabStrategy))
            {
                partLongDatas = context.GetRAMLongData(productId);
            }
            else if (tabType == typeof(CaseTabStrategy))
            {
                partLongDatas = context.GetCaseLongData(productId);
            }
            else if (tabType == typeof(CaseFanTabStrategy))
            {
                partLongDatas = context.GetCaseFanLongData(productId);
            }
            else if (tabType == typeof(GPUTabStrategy))
            {
                partLongDatas = context.GetGPULongData(productId);
            }
            else if (tabType == typeof(HybridStorageTabStrategy))
            {
                partLongDatas = context.GetHybridStorageLongData(productId);
            }

            ProductItemViewModel model = new ProductItemViewModel(partLongDatas);
            DataContext = model;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии ссылки: {ex.Message}");
            }
        }

        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Backed?.Invoke(_tabType);
        }
    }
}
