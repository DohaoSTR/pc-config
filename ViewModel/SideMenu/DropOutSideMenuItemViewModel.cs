using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PCConfig.ViewModel.SideMenu
{
    public class DropOutSideMenuItemViewModel : INotifyPropertyChanged, ISideMenuItem
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

        private ObservableCollection<ISideMenuItem> _sideMenuItems;

        public ObservableCollection<ISideMenuItem> SideMenuItems
        {
            get => _sideMenuItems;
            set
            {
                _sideMenuItems = value;
                OnPropertyChanged(nameof(SideMenuItems));
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

        public DropOutSideMenuItemViewModel(string text, string kind, IEnumerable<ISideMenuItem> menuItems, SideMenuItemLocationType locationType)
        {
            _text = text;
            _kind = kind;
            _isSelected = false;

            _sideMenuItems = new ObservableCollection<ISideMenuItem>(menuItems);

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
