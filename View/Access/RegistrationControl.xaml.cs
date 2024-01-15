using PCConfig.View.Access;
using PCConfig.ViewModel.Access;
using System.Windows;
using System.Windows.Controls;

namespace PCConfig.View
{
    /// <summary>
    /// Interaction logic for RegistrationControl.xaml
    /// </summary>
    public partial class RegistrationControl : UserControl, IAccessControl
    {
        public string StandardTitle => "Регистрация";

        public RegistrationControl()
        {
            InitializeComponent();

            DataContext = new RegistrationViewModel();
        }

        public RegistrationControl(string email, string password)
        {
            InitializeComponent();

            DataContext = new RegistrationViewModel(email, password);
            PasswordTextBox.Password = ((dynamic)DataContext).Password;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            { ((dynamic)DataContext).Password = ((PasswordBox)sender).Password; }
        }
    }
}
