using PCConfig.ViewModel.SideMenu.Tabs.Realizations.GameData;
using System.Windows.Controls;

namespace PCConfig.View.Tabs
{
    /// <summary>
    /// Interaction logic for GameListControl.xaml
    /// </summary>
    public partial class GameListControl : UserControl
    {
        public event Action Backed;
        public event Action<string, int, string> Clicked;

        public GameListControl()
        {
            InitializeComponent();

            GameListViewModel model = new();
            model.GameAreaClicked += Model_GameAreaClicked;

            DataContext = model;
        }

        private void Model_GameAreaClicked(GameListItemViewModel model)
        {
            Clicked?.Invoke(model.Name, model.Samples, model.ImageUrl);
        }
    }
}
