using PCConfig.ViewModel;
using PCConfig.ViewModel.SideMenu.Tabs.Realizations.GameData;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace PCConfig.View.Tabs
{
    /// <summary>
    /// Interaction logic for GameDataControl.xaml
    /// </summary>
    public partial class GameDataControl : UserControl
    {
        private int _lastHeight = 0;

        private const int standardItemsPerPage = 11;

        public event Action Backed;

        public GameDataControl(string gameName, int samples, string imageUrl)
        {
            InitializeComponent();

            DataContext = new GameDataViewModel(gameName, samples, imageUrl, standardItemsPerPage);
            Loaded += MainWindow_Loaded;
        }

        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Backed?.Invoke();
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
            GameDataViewModel dataContext = DataContext as GameDataViewModel;

            if (CurrentPageNumberTextBox.Text is not null && int.TryParse(CurrentPageNumberTextBox.Text, out int pageNumber))
            {
                if (pageNumber - 1 > 0)
                {
                    dataContext.CurrentPageIndex = pageNumber - 1;
                    dataContext.LoadData();
                }
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            int height = (int)LogsGrid.ActualHeight;

            GameDataViewModel panel = DataContext as GameDataViewModel;
            panel.ItemsPerPage = GetItemsPerPage(height);
        }

        private void OnDataGridSizeChanged(object sender, SizeChangedEventArgs e)
        {
            int height = (int)LogsGrid.ActualHeight;

            if (_lastHeight != height)
            {
                (DataContext as GameDataViewModel).ItemsPerPage = GetItemsPerPage(height);
            }
        }

        private int GetItemsPerPage(int height)
        {
            _lastHeight = height;
            int rowHeight = 40;
            int rowCount = (height - 15) / rowHeight;

            return rowCount;
        }

        private void FPSDataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            e.Handled = true;

            if (CollectionViewSource.GetDefaultView(LogsGrid.ItemsSource) is ListCollectionView collectionView)
            {
                ListSortDirection direction = e.Column.SortDirection == ListSortDirection.Descending ? ListSortDirection.Ascending : ListSortDirection.Descending;
                GameDataViewModel model = DataContext as GameDataViewModel;

                FPSDataGridSorter sorter = new(model.ViewData);
                List<FPSDataView> sortedList = sorter.Sort(e.Column.SortMemberPath, direction);
                model.SetViewData(sortedList);

                e.Column.SortDirection = direction;
            }
        }
    }
}
