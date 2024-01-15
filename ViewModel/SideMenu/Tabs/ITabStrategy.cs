using System.Windows.Controls;

namespace PCConfig.ViewModel.SideMenu.Tabs
{
    public interface ITabStrategy
    {
        Control HandleTab(SideMenuItemViewModel item);
    }
}
