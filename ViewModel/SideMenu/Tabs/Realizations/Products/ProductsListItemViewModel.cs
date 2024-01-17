using PCConfig.Model.PcPartPicker;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Media.Imaging;

using PcPartPickerPart = PCConfig.Model.PcPartPicker.Entities.Part;

namespace PCConfig.ViewModel.SideMenu.Tabs.Realizations.Products
{
    public class ProductsListItemViewModel : INotifyPropertyChanged
    {
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

        public BitmapImage ImageSource
        {
            get
            {
                if (_imagesUrls?.Count() == 0 || _imagesUrls == null)
                {
                    string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

                    DirectoryInfo parentDirectory = Directory.GetParent(currentDirectory).Parent.Parent.Parent;

                    string parentPath = parentDirectory.FullName;
                    string relativePath = Path.Combine(parentPath, "product_without_image.jpg");
                    string filePath = Path.Combine(currentDirectory, relativePath);

                    Uri imageUri = new(filePath, UriKind.Absolute);
                    BitmapImage bitmapImage = new(imageUri);

                    return bitmapImage;
                }
                else
                {
                    return Images[0];
                }
            }
        }

        private PcPartPickerPart _part;
        public PcPartPickerPart Part
        {
            get
            {
                return _part;
            }
        }

        private readonly IEnumerable<ShortSpecification> _specifications;
        public ObservableCollection<ShortSpecification> Specifications
        {
            get
            {
                return new ObservableCollection<ShortSpecification>(_specifications);
            }
        }

        private PartViewData _data;
        public PartViewData PartViewData
        {
            get
            {
                return _data;
            }
        }

        private int _number;
        public int Number
        {
            get
            {
                return _number;
            }
        }

        public ProductsListItemViewModel(int number, PartShortData shortData)
        {
            _imagesUrls = shortData.ImagesUrls;
            _part = shortData.Part;
            _data = shortData.PartViewData;
            _specifications = shortData.Specifications;

            _number = number;
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
