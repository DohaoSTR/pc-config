using PCConfig.View.Access;
using PCConfig.ViewModel.Access;
using System.Windows;
using System.Windows.Controls;

namespace PCConfig.View
{
    /// <summary>
    /// Interaction logic for ChangePasswordControl.xaml
    /// </summary>
    public partial class ChangePasswordControl : UserControl, IAccessControl
    {
        public string StandardTitle => "Смена пароля";

        public ChangePasswordControl(string email)
        {
            InitializeComponent();

            DataContext = new ChangePasswordViewModel(email);
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