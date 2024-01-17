using GalaSoft.MvvmLight.Command;
using PCConfig.Model.Converters;
using PCConfig.Model.PcPartPicker;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace PCConfig.ViewModel.SideMenu.Tabs.Realizations.Products
{
    public class ProductsListViewModel : INotifyPropertyChanged
    {
        #region Page Main

        private ObservableCollection<ProductsListItemViewModel> _data;
        private ObservableCollection<ProductsListItemViewModel> _pageData;

        public ObservableCollection<ProductsListItemViewModel> Data
        {
            get => _data;
            set
            {
                _data = value;
                OnPropertyChanged(nameof(Data));

                SetViewData(value);
            }
        }

        public ObservableCollection<ProductsListItemViewModel> ViewData { get; private set; }

        public void SetViewData(IEnumerable<ProductsListItemViewModel> data)
        {
            ObservableCollection<ProductsListItemViewModel> viewData = new(data);

            ViewData = viewData;
            OnPropertyChanged(nameof(ViewData));

            LoadData();
        }

        public ObservableCollection<ProductsListItemViewModel> PageData
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
                    SetViewData(new List<ProductsListItemViewModel>());
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

            IEnumerable<ProductsListItemViewModel> currentPageData = ViewData.Skip(startIndex).Take(ItemsPerPage);

            PageData = new ObservableCollection<ProductsListItemViewModel>(currentPageData);
            UpdatePageButtons();
        }

        #endregion

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

        private string _partType;
        public string PartType
        {
            get
            {
                return _partType;
            }
        }

        private IQueryable<PartShortData> _queryable;
        private Type _strategyType;

        public ProductsListViewModel(string partType, IQueryable<PartShortData> queryable, Type strategyType)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();

            ProductsCategoryConverter converter = new ProductsCategoryConverter();
            _partType = (string?)converter.Convert(partType, null, null, null);

            _currentPageIndex = 0;
            _itemsPerPage = 6;
            _strategyType = strategyType;
            _queryable = queryable;

            List<PartShortData> parts = queryable.ToList();

            List<ProductsListItemViewModel> items = new List<ProductsListItemViewModel>();
            int index = 1;
            foreach (PartShortData part in parts)
            {
                items.Add(new ProductsListItemViewModel(index, part));
                index++;
            }

            _data = new ObservableCollection<ProductsListItemViewModel>(items);
            SetViewData(_data);
            LoadData();

            stopwatch.Stop();
            Debug.WriteLine($"Время выполнения ProductsListViewModel: {stopwatch.Elapsed.TotalSeconds} секунд");
        }

        public ICommand GoToItemCommand => new RelayCommand<ProductsListItemViewModel>(GoToProductItem);

        public event Action<ProductsListItemViewModel, Type> ProductClicked;

        private void GoToProductItem(ProductsListItemViewModel menuItem)
        {
            ProductClicked?.Invoke(menuItem, _strategyType);
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
