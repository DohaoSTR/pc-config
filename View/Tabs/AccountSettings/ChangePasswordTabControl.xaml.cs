using PCConfig.ViewModel.SideMenu.Tabs.Realizations.AccountSettings;
using System.Windows;
using System.Windows.Controls;

namespace PCConfig.View.Tabs
{
    /// <summary>
    /// Interaction logic for ChangePasswordTabControl.xaml
    /// </summary>
    public partial class ChangePasswordTabControl : UserControl
    {
        public event Action BackButtonClicked;
        public event Action PasswordChangeProccedureExecute;

        public ChangePasswordTabControl(int userId, string email)
        {
            InitializeComponent();

            ChangePasswordTabViewModel model = new(userId, email);
            model.BackButtonClicked += Model_BackButtonClicked;
            model.ChangePasswordButtonClicked += Model_ChangePasswordButtonClicked;
            DataContext = model;
        }

        private void Model_ChangePasswordButtonClicked()
        {
            PasswordChangeProccedureExecute?.Invoke();
        }

        private void Model_BackButtonClicked()
        {
            BackButtonClicked?.Invoke();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            { ((dynamic)DataContext).Password = ((PasswordBox)sender).Password; }
        }

        private void RepeatPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            { ((dynamic)DataContext).RepeatPassword = ((PasswordBox)sender).Password; }
        }
    }
}
