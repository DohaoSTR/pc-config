using PCConfig.View.Tabs;
using System.Windows.Controls;

namespace PCConfig.ViewModel.SideMenu.Tabs.Strategies
{
    public class AccountSettingsTabStrategy : ITabStrategy
    {
        public event Action<string> ChangePassword;

        private readonly int _userId;

        public AccountSettingsTabStrategy(int userId)
        {
            _userId = userId;
        }

        public Control HandleTab(SideMenuItemViewModel item)
        {
            AccountSettingsControl control = new(_userId);
            control.ChangePasswordButtonClick += ChangePassword;

            return control;
        }
    }
}
