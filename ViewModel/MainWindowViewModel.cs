using GalaSoft.MvvmLight.Command;
using PCConfig.ViewModel.SideMenu;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace PCConfig.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region SideMenu Fields

        private ISideMenuItem _currentSideMenuItem;

        private ObservableCollection<ISideMenuItem> _sideMenuItems;

        public ISideMenuItem CurrentSideMenuItem
        {
            get => _currentSideMenuItem;
            set
            {
                _currentSideMenuItem = value;
                OnPropertyChanged(nameof(CurrentSideMenuItem));
            }
        }

        public ObservableCollection<ISideMenuItem> SideMenuItems
        {
            get => _sideMenuItems;
            set
            {
                _sideMenuItems = value;
                OnPropertyChanged(nameof(SideMenuItems));
            }
        }

        private ObservableCollection<ISideMenuItem> _upperSideMenuItems;
        public ObservableCollection<ISideMenuItem> UpperSideMenuItems
        {
            get => _upperSideMenuItems;
            set
            {
                _upperSideMenuItems = value;
                OnPropertyChanged(nameof(UpperSideMenuItems));
            }
        }

        public event Action ExitButtonClicked;

        #endregion

        public MainWindowViewModel(IEnumerable<ISideMenuItem> menuItems)
        {
            _upperSideMenuItems = new ObservableCollection<ISideMenuItem>(menuItems);

            _sideMenuItems = [];
            foreach (ISideMenuItem item in menuItems)
            {
                if (item.GetType() == typeof(DropOutSideMenuItemViewModel))
                {
                    DropOutSideMenuItemViewModel dropOutMenuItem = (DropOutSideMenuItemViewModel)item;
                    foreach (ISideMenuItem sideMenuItem in dropOutMenuItem.SideMenuItems)
                    {
                        _sideMenuItems.Add(sideMenuItem);
                    }
                }
                else
                {
                    _sideMenuItems.Add(item);
                }
            }

            CurrentSideMenuItem = SideMenuItems[0];
        }

        #region SideMenu Commands

        public ICommand GoToMenuItemCommand => new RelayCommand<SideMenuItemViewModel>(GoToMenuItem);

        private void GoToMenuItem(ISideMenuItem menuItem)
        {
            if (menuItem.GetType() == typeof(SideMenuItemViewModel))
            {
                SideMenuItemViewModel currentMenuItem = (SideMenuItemViewModel)CurrentSideMenuItem;
                int currentMenuItemIndex = SideMenuItems.IndexOf(currentMenuItem);
                SideMenuItems.Remove(currentMenuItem);
                currentMenuItem.IsSelected = false;
                SideMenuItems.Insert(currentMenuItemIndex, currentMenuItem);

                int index = SideMenuItems.IndexOf(menuItem);
                SideMenuItems.Remove(menuItem);
                menuItem.IsSelected = true;
                SideMenuItems.Insert(index, menuItem);

                CurrentSideMenuItem = SideMenuItems[index];
            }
        }

        public ICommand ExitFromAccountCommand => new RelayCommand(ExitFromAccount);

        private void ExitFromAccount()
        {
            ExitButtonClicked?.Invoke();
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
