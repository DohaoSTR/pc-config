using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace PCConfig.ViewModel.SideMenu.Tabs.Realizations.GameData
{
    public class GameListItemViewModel : INotifyPropertyChanged
    {
        public string Name { get; }

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

        public GameListItemViewModel(string name, int samples, string imageUrl)
        {
            Name = name;
            Samples = samples;
            ImageUrl = imageUrl;
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
