using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace PCConfig.ViewModel.SideMenu.Tabs
{
    public class TabMenuViewModel : INotifyPropertyChanged
    {
        private TabMenuItemViewModel _currentMenuItem;

        private ObservableCollection<TabMenuItemViewModel> _menuItems;

        public TabMenuItemViewModel CurrentMenuItem
        {
            get => _currentMenuItem;
            set
            {
                _currentMenuItem = value;
                OnCurrentMenuItemChanged(nameof(CurrentMenuItem));
                OnPropertyChanged(nameof(CurrentMenuItem));
            }
        }

        public ObservableCollection<TabMenuItemViewModel> MenuItems
        {
            get => _menuItems;
            set
            {
                _menuItems = value;
                OnPropertyChanged(nameof(MenuItems));
            }
        }

        public TabMenuViewModel(List<TabMenuItemViewModel> tabItems)
        {
            _menuItems = new ObservableCollection<TabMenuItemViewModel>(tabItems);
            CurrentMenuItem = MenuItems[0];
            MenuItems[0].IsSelected = true;
        }

        #region SideMenu Commands

        public ICommand GoToMenuItemCommand => new RelayCommand<TabMenuItemViewModel>(GoToMenuItem);

        private void GoToMenuItem(TabMenuItemViewModel menuItem)
        {
            TabMenuItemViewModel currentMenuItem = CurrentMenuItem;
            int currentMenuItemIndex = MenuItems.IndexOf(currentMenuItem);
            MenuItems.Remove(currentMenuItem);
            currentMenuItem.IsSelected = false;
            MenuItems.Insert(currentMenuItemIndex, currentMenuItem);

            int index = MenuItems.IndexOf(menuItem);
            MenuItems.Remove(menuItem);
            menuItem.IsSelected = true;
            MenuItems.Insert(index, menuItem);

            CurrentMenuItem = MenuItems[index];
        }

        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler CurrentMenuItemChanged;

        protected virtual void OnCurrentMenuItemChanged(string propertyName)
        {
            CurrentMenuItemChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
