using PCConfig.Model.PcPartPicker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using PCConfig.Model.GeneratePC;

namespace PCConfig.ViewModel.SideMenu.Tabs.Realizations.GenerationModel
{
    public class GeneratedPC : INotifyPropertyChanged
    {
        public GeneratedPCStats Stats { get; set; }

        private Visibility _PCVisibility = Visibility.Visible;
        public Visibility PCVisibility
        {
            get { return _PCVisibility; }
            set
            {
                if (_PCVisibility != value)
                {
                    _PCVisibility = value;
                    OnPropertyChanged(nameof(PCVisibility));
                }
            }
        }

        private string __PCIconKind = "MenuUp";
        public string PCIconKind
        {
            get { return __PCIconKind; }
            set
            {
                if (__PCIconKind != value)
                {
                    __PCIconKind = value;
                    OnPropertyChanged(nameof(PCIconKind));
                }
            }
        }

        public ICommand ChangePCVisibilityCommand => new RelayCommand(ChangePCVisibility);

        public void ChangePCVisibility()
        {
            PCVisibility = PCVisibility == Visibility.Visible
                ? Visibility.Collapsed
                : Visibility.Visible;

            PCIconKind = PCIconKind == "MenuUp"
                ? "MenuDown"
                : "MenuUp";
        }

        public ObservableCollection<PartShortData> Parts { get; set; }

        public string IndexString { get; set; }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
