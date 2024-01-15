using PCConfig.ViewModel;
using PCConfig.ViewModel.AccountSettings;
using PCConfig.ViewModel.SideMenu.Tabs.Realizations.AccountSettings;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace PCConfig.View.Tabs
{
    /// <summary>
    /// Interaction logic for AccountSettingsControl.xaml
    /// </summary>
    public partial class AccountSettingsControl : UserControl
    {
        public event Action<string> ChangePasswordButtonClick;

        private int _lastHeight = 0;

        private const int standardItemsPerPage = 11;

        private readonly int _userId;

        public AccountSettingsControl(int userId)
        {
            InitializeComponent();

            _userId = userId;

            AccountSettingsViewModel model = new(userId, standardItemsPerPage);
            model.ChangePasswordButtonClick += Model_ChangePasswordButtonClick;
            DataContext = model;
            Loaded += MainWindow_Loaded;
        }

        private void Model_ChangePasswordButtonClick(string email)
        {
            MessageBoxResult result = MessageBox.Show("Вы точно хотите сменить пароль? При нажатии 'да' произойдет отправка кода восстановления на ваш email.", "Смена пароля", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                ChangePasswordButtonClick?.Invoke(email);
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
            AccountSettingsViewModel dataContext = DataContext as AccountSettingsViewModel;

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

            AccountSettingsViewModel panel = DataContext as AccountSettingsViewModel;
            panel.ItemsPerPage = GetItemsPerPage(height);
        }

        private void OnDataGridSizeChanged(object sender, SizeChangedEventArgs e)
        {
            int height = (int)LogsGrid.ActualHeight;

            if (_lastHeight != height)
            {
                (DataContext as AccountSettingsViewModel).ItemsPerPage = GetItemsPerPage(height);
            }
        }

        private int GetItemsPerPage(int height)
        {
            _lastHeight = height;
            int rowHeight = 40;
            int rowCount = (height - 15) / rowHeight;

            return rowCount;
        }

        private void LogsDataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            e.Handled = true;

            if (CollectionViewSource.GetDefaultView(LogsGrid.ItemsSource) is ListCollectionView collectionView)
            {
                ListSortDirection direction = e.Column.SortDirection == ListSortDirection.Descending ? ListSortDirection.Ascending : ListSortDirection.Descending;
                AccountSettingsViewModel model = DataContext as AccountSettingsViewModel;

                LogsDataGridSorter sorter = new(model.ViewData);
                List<LogView> sortedList = sorter.Sort(e.Column.SortMemberPath, direction);
                model.SetViewData(sortedList);

                e.Column.SortDirection = direction;
            }
        }
    }
}