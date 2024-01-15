using GalaSoft.MvvmLight.Command;
using PCConfig.Model.Contexts;
using PCConfig.Model.Converters;
using PCConfig.Model.UsersData;
using PCConfig.ViewModel.AccountSettings;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace PCConfig.ViewModel.SideMenu.Tabs.Realizations.AccountSettings
{
    public class AccountSettingsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<LogView> _data;
        private ObservableCollection<LogView> _pageData;

        public ObservableCollection<LogView> Data
        {
            get => _data;
            set
            {
                _data = value;
                OnPropertyChanged(nameof(Data));

                SetViewData(value);
            }
        }

        public ObservableCollection<LogView> ViewData { get; private set; }

        public void SetViewData(IEnumerable<LogView> data)
        {
            ObservableCollection<LogView> viewData = new(data);

            ViewData = viewData;
            OnPropertyChanged(nameof(ViewData));

            LoadData();
        }

        public ObservableCollection<LogView> PageData
        {
            get => _pageData;
            set
            {
                _pageData = value;
                OnPropertyChanged(nameof(PageData));
            }
        }

        private int _currentPageIndex;
        private int _itemsPerPage;

        public int CurrentPageIndex
        {
            get => _currentPageIndex;
            set
            {
                _currentPageIndex = value < 0 || TotalPages == 0 ? 0 : value >= TotalPages ? TotalPages - 1 : value;

                OnPropertyChanged(nameof(CurrentPageIndex));
            }
        }

        public int ItemsPerPage
        {
            get => _itemsPerPage;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                if (value == 0 && _itemsPerPage != value)
                {
                    SetViewData(new List<LogView>());
                    _currentPageIndex = 0;
                    OnPropertyChanged(nameof(ViewData));
                }

                if (_itemsPerPage != value)
                {
                    _itemsPerPage = value;
                    OnPropertyChanged(nameof(ItemsPerPage));
                }

                SetViewData(_data);
            }
        }

        public int TotalPages => _itemsPerPage <= 0 || ViewData.Count <= 0 ? 0 : (int)Math.Ceiling((double)ViewData.Count / _itemsPerPage);

        private void NormalizeCurrentPageIndex()
        {
            int startIndex = CurrentPageIndex * ItemsPerPage;
            int maxIndex = ViewData.Count - 1;

            if (ItemsPerPage == 0 || ViewData.Count == 0 || startIndex < 0)
            {
                CurrentPageIndex = 0;
            }
            else if (startIndex > maxIndex)
            {
                CurrentPageIndex = maxIndex / ItemsPerPage;
            }
        }

        public void LoadData()
        {
            NormalizeCurrentPageIndex();

            int startIndex = CurrentPageIndex * ItemsPerPage;

            IEnumerable<LogView> currentPageData = ViewData.Skip(startIndex).Take(ItemsPerPage);

            PageData = new ObservableCollection<LogView>(currentPageData);
            UpdatePageButtons();
        }

        #region Page Buttons

        private ObservableCollection<PageButtonViewModel> _pageButtons;

        public ObservableCollection<PageButtonViewModel> PageButtons
        {
            get => _pageButtons;
            set
            {
                _pageButtons = value;
                OnPropertyChanged(nameof(PageButtons));
            }
        }

        private void UpdatePageButtons()
        {
            int totalButtons = Math.Min(5, TotalPages);
            int startIndex = Math.Max(1, CurrentPageIndex - (totalButtons / 2));
            int endIndex = Math.Min(startIndex + totalButtons, TotalPages);

            PageButtons = new ObservableCollection<PageButtonViewModel>(
                Enumerable.Range(startIndex, endIndex - startIndex + 1)
                .Select(i => new PageButtonViewModel { IsSelected = i == CurrentPageIndex + 1, Number = i })
            );
        }

        #endregion

        #region Page Commands

        public ICommand NextPageCommand => new RelayCommand(NextPage, () => CurrentPageIndex < TotalPages - 1);

        public ICommand PreviousPageCommand => new RelayCommand(PreviousPage, () => CurrentPageIndex > 0);

        public ICommand GoToPageCommand => new RelayCommand<int>(GoToPage);

        public ICommand DoubleNextPageCommand => new RelayCommand(DoubleNextPage, () => CurrentPageIndex < TotalPages - 1);

        public ICommand DoublePreviousPageCommand => new RelayCommand(DoublePreviousPage, () => CurrentPageIndex > 0);

        private void GoToPage(int pageNumber)
        {
            if (pageNumber >= 1 && pageNumber <= TotalPages)
            {
                CurrentPageIndex = pageNumber - 1;
                LoadData();
            }
        }

        private void NextPage()
        {
            if (CurrentPageIndex < TotalPages - 1)
            {
                CurrentPageIndex++;
                LoadData();
            }
        }

        private void PreviousPage()
        {
            if (CurrentPageIndex > 0)
            {
                CurrentPageIndex--;
                LoadData();
            }
        }

        private void DoubleNextPage()
        {
            if (CurrentPageIndex < TotalPages - 1)
            {
                CurrentPageIndex = TotalPages - 1;
                LoadData();
            }
        }

        private void DoublePreviousPage()
        {
            if (CurrentPageIndex > 0)
            {
                CurrentPageIndex = 0;
                LoadData();
            }
        }

        #endregion

        private readonly UserDataContext _context;

        private readonly User _user;
        private readonly Role _role;

        public UserType UserType => _user.Type;

        public string RoleName
        {
            get
            {
                RoleNameConverter converter = new();
                return (string)converter.Convert(_role.Name, null, null, null);
            }
        }

        public string Email => _user.Email;

        public AccountSettingsViewModel(int userId, int itemsPerPage)
        {
            _context = new UserDataContext();

            _user = _context.GetUserData(userId);
            List<Log> logs = new(_context.GetUserLogs(userId));
            _role = _context.GetUserRole(userId);

            _currentPageIndex = 0;
            _itemsPerPage = itemsPerPage;

            List<LogView> logViews = [];
            int index = 1;
            foreach (Log item in logs)
            {
                logViews.Add(new LogView(item, index));
                index++;
            }

            _data = new ObservableCollection<LogView>(logViews);
            SetViewData(_data);
            LoadData();
        }

        #region ChangePassword Commands

        public ICommand ChangePasswordCommand => new RelayCommand(ChangePassword);

        public event Action<string> ChangePasswordButtonClick;

        private void ChangePassword()
        {
            ChangePasswordButtonClick?.Invoke(Email);
        }

        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
