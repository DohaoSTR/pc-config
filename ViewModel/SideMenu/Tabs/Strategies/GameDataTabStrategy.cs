using PCConfig.View.Tabs;
using System.Windows.Controls;

namespace PCConfig.ViewModel.SideMenu.Tabs.Strategies
{
    public class GameDataTabStrategy : ITabStrategy
    {
        public event Action Backed;
        public event Action<string, int, string> Clicked;

        public Control HandleTab(SideMenuItemViewModel item)
        {
            GameListControl control = new();
            control.Backed += Backed;
            control.Clicked += Clicked;

            return control;
        }
    }
}
