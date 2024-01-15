using GalaSoft.MvvmLight.Command;
using PCConfig.Model.Contexts;
using PCConfig.Model.UserBenchmark;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace PCConfig.ViewModel.SideMenu.Tabs.Realizations.GameData
{
    public class GameListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<GameListItemViewModel> _games;

        public ObservableCollection<GameListItemViewModel> Games
        {
            get => _games;
            set
            {
                _games = value;
                OnPropertyChanged(nameof(Games));
            }
        }

        public GameListViewModel()
        {
            UserBenchmarkContext context = new();

            Stopwatch stopwatch = new();
            stopwatch.Start();

            List<GameListItemViewModel> menuItems = [];
            List<GameWithTotalSamples> gamesData = (List<GameWithTotalSamples>)context.GetGamesWithTotalSamples();

            foreach (GameWithTotalSamples gameData in gamesData)
            {
                menuItems.Add(new GameListItemViewModel(gameData.Name, gameData.TotalSamples, gameData.ImageLink));
            }

            stopwatch.Stop();
            Debug.WriteLine($"Время выполнения GameListViewModel: {stopwatch.Elapsed.TotalSeconds} секунд");

            menuItems = menuItems.OrderByDescending(item => item.Samples).ToList();

            Games = new ObservableCollection<GameListItemViewModel>(menuItems);
        }

        public ICommand GoToGameItemCommand => new RelayCommand<GameListItemViewModel>(GoToGameItem);

        public event Action<GameListItemViewModel> GameAreaClicked;

        private void GoToGameItem(GameListItemViewModel menuItem)
        {
            GameAreaClicked?.Invoke(menuItem);
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
