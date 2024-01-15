using System.Windows.Controls;

namespace PCConfig.ViewModel.SideMenu.Tabs.Strategies
{
    public class ConfiguratorTabStrategy : ITabStrategy
    {
        public Control HandleTab(SideMenuItemViewModel item)
        {
            return new Control();
        }
    }
}
