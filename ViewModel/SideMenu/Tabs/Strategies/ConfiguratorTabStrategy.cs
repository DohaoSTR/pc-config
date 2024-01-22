using PCConfig.View.Tabs.Configurator;
using System.Windows.Controls;

namespace PCConfig.ViewModel.SideMenu.Tabs.Strategies
{
    public class ConfiguratorTabStrategy : ITabStrategy
    {
        public Control HandleTab(SideMenuItemViewModel item)
        {
            ConfiguratorControl control = new ConfiguratorControl();
            return control;
        }
    }
}
