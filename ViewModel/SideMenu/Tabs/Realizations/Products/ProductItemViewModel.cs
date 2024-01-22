using PCConfig.Model.PcPartPicker;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace PCConfig.ViewModel.SideMenu.Tabs.Realizations.Products
{
    public class ProductItemViewModel : INotifyPropertyChanged
    {
        private PartLongData _partLongData;
        public PartLongData PartLongData
        {
            get
            {
                return _partLongData;
            }
        }

        private readonly IEnumerable<string> _imagesUrls;
        public ObservableCollection<BitmapImage> Images
        {
            get
            {
                ObservableCollection<BitmapImage> list = [];
                foreach (string url in _imagesUrls)
                {
                    try
                    {
                        Uri imageUri = new(url, UriKind.Absolute);
                        BitmapImage bitmapImage = new(imageUri);
                        list.Add(bitmapImage);
                    }
                    catch (UriFormatException) { }
                }

                return list;
            }
        }

        public ProductItemViewModel(PartLongData longData)
        {
            _partLongData = longData;
            _imagesUrls = longData.ImagesUrls;
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
