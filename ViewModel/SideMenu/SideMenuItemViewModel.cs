using System.ComponentModel;

namespace PCConfig.ViewModel.SideMenu
{
    public class SideMenuItemViewModel : INotifyPropertyChanged, ISideMenuItem
    {
        private SideMenuItemLocationType _locationType;

        public SideMenuItemLocationType LocationType
        {
            get => _locationType;
            set
            {
                _locationType = value;
                OnPropertyChanged(nameof(LocationType));
            }
        }

        private bool _isSelected;

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnIsSelectedPropertyChanged(nameof(IsSelected));
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        private string _text;

        public string Text
        {
            get => _text;
            set
            {
                if (_text != value)
                {
                    _text = value;
                    OnPropertyChanged(nameof(Text));
                }
            }
        }

        private string _kind;

        public string Kind
        {
            get => _kind;
            set
            {
                if (_kind != value)
                {
                    _kind = value;
                    OnPropertyChanged(nameof(Kind));
                }
            }
        }

        public SideMenuItemViewModel(string text, string kind, SideMenuItemLocationType locationType)
        {
            _text = text;
            _kind = kind;
            _isSelected = false;
            _locationType = locationType;
        }

        public SideMenuItemViewModel(string text, string kind, SideMenuItemLocationType locationType, bool isSelected)
        {
            _text = text;
            _kind = kind;
            _isSelected = isSelected;
            _locationType = locationType;
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler IsSelectedPropertyChanged;

        protected virtual void OnIsSelectedPropertyChanged(string propertyName)
        {
            IsSelectedPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
