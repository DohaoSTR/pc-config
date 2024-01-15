using GalaSoft.MvvmLight.Command;
using PCConfig.Model.Contexts;
using PCConfig.Model.UserBenchmark;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PCConfig.ViewModel.SideMenu.Tabs.Realizations.GameData
{
    public class GameDataViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<FPSDataView> _data;
        private ObservableCollection<FPSDataView> _pageData;

        public ObservableCollection<FPSDataView> Data
        {
            get => _data;
            set
            {
                _data = value;
                OnPropertyChanged(nameof(Data));

                SetViewData(value);
            }
        }

        public ObservableCollection<FPSDataView> ViewData { get; private set; }

        public void SetViewData(IEnumerable<FPSDataView> data)
        {
            ObservableCollection<FPSDataView> viewData = new(data);

            ViewData = viewData;
            OnPropertyChanged(nameof(ViewData));

            LoadData();
        }

        public ObservableCollection<FPSDataView> PageData
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
                    SetViewData(new List<FPSDataView>());
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

            IEnumerable<FPSDataView> currentPageData = ViewData.Skip(startIndex).Take(ItemsPerPage);

            PageData = new ObservableCollection<FPSDataView>(currentPageData);
            UpdatePageButtons();
        }

        public string GameName { get; }

        public int Samples { get; }

        public string ImageUrl { get; }
        public BitmapImage ImageSource
        {
            get
            {
                Uri imageUri = new(ImageUrl, UriKind.Absolute);
                BitmapImage bitmapImage = new(imageUri);

                return bitmapImage;
            }
        }

        public GameDataViewModel(string gameName, int samples, string imageUrl, int itemsPerPage)
        {
            UserBenchmarkContext context = new();

            List<FPSDataWithModels> fpsDatas = context.GetFPSDataByGameName(gameName).ToList();

            _currentPageIndex = 0;
            _itemsPerPage = itemsPerPage;
            Samples = samples;
            GameName = gameName;
            ImageUrl = imageUrl;

            List<FPSDataView> views = [];
            int index = 1;
            foreach (FPSDataWithModels item in fpsDatas)
            {
                views.Add(new FPSDataView(item, index));
                index++;
            }

            _data = new ObservableCollection<FPSDataView>(views);
            SetViewData(_data);
            LoadData();
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

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
