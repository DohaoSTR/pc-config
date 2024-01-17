using PCConfig.Model.PcPartPicker;
using PCConfig.ViewModel;
using PCConfig.ViewModel.SideMenu.Tabs.Realizations.Products;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace PCConfig.View.Tabs.Products
{
    /// <summary>
    /// Interaction logic for ProductControl.xaml
    /// </summary>
    public partial class ProductControl : UserControl
    {
        public event Action<ProductsListItemViewModel, Type> ProductClicked;

        public ProductControl(string partType, IQueryable<PartShortData> parts, Type strategyType)
        {
            InitializeComponent();

            ProductsListViewModel model = new ProductsListViewModel(partType, parts, strategyType);
            model.ProductClicked += Model_ProductClicked;
            DataContext = model;
        }

        private void Model_ProductClicked(ProductsListItemViewModel obj, Type type)
        {
            ProductClicked?.Invoke(obj, type);
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

        private void PageButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;

            if (button.DataContext is PageButtonViewModel pageButtonViewModel)
            {
                bool isSelected = pageButtonViewModel.IsSelected;

                if (isSelected == false)
                {
                    button.Background = (Brush)new BrushConverter().ConvertFrom("#7950f2");
                    button.Foreground = (Brush)new BrushConverter().ConvertFrom("#ffffff");
                }
            }
        }

        private void PageButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;

            if (button.DataContext is PageButtonViewModel pageButtonViewModel)
            {
                bool isSelected = pageButtonViewModel.IsSelected;

                if (isSelected == false)
                {
                    button.Background = Brushes.Transparent;
                    button.Foreground = (Brush)new BrushConverter().ConvertFrom("#6c7682");
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProductsListViewModel dataContext = DataContext as ProductsListViewModel;

            if (CurrentPageNumberTextBox.Text is not null && int.TryParse(CurrentPageNumberTextBox.Text, out int pageNumber))
            {
                if (pageNumber - 1 > 0)
                {
                    dataContext.CurrentPageIndex = pageNumber - 1;
                    dataContext.LoadData();
                }
            }
        }
    }
}