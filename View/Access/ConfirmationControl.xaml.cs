using PCConfig.View.Access;
using PCConfig.ViewModel.Access;
using System.Windows.Controls;

namespace PCConfig.View
{
    /// <summary>
    /// Interaction logic for ConfirmationControl.xaml
    /// </summary>
    public partial class ConfirmationControl : UserControl, IAccessControl
    {
        public string StandardTitle => "Восстановление доступа";

        public ConfirmationControl(int code, string email, string password)
        {
            InitializeComponent();

            DataContext = new ConfirmationViewModel(code, email, password);
        }

        public ConfirmationControl(int code, string email)
        {
            InitializeComponent();

            DataContext = new RestoreConfirmationViewModel(code, email);
        }
    }
}
