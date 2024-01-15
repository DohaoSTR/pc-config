using PCConfig.View.Access;
using PCConfig.ViewModel.Access;
using System.Windows;
using System.Windows.Controls;

namespace PCConfig.View
{
    /// <summary>
    /// Interaction logic for AuthenticationControl.xaml
    /// </summary>
    public partial class AuthenticationControl : UserControl, IAccessControl
    {
        public string StandardTitle => "Авторизация";

        public AuthenticationControl()
        {
            InitializeComponent();

            DataContext = new AuthenticationViewModel();
            PasswordTextBox.Password = ((dynamic)DataContext).Password;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            { ((dynamic)DataContext).Password = ((PasswordBox)sender).Password; }
        }
    }
}
