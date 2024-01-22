using PCConfig.View.Tabs.GenerationModel;
using System.Windows.Controls;

namespace PCConfig.ViewModel.SideMenu.Tabs.Strategies
{
    public class GenerationAssemblyTabStrategy : ITabStrategy
    {
        public Control HandleTab(SideMenuItemViewModel item)
        {
            GenerationModelControl control = new GenerationModelControl();

            return control;
        }
    }
}
