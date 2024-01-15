using PCConfig.View.Access;
using PCConfig.ViewModel.Access;
using System.Windows.Controls;

namespace PCConfig.View
{
    /// <summary>
    /// Interaction logic for RestoreAccessControl.xaml
    /// </summary>
    public partial class RestoreAccessControl : UserControl, IAccessControl
    {
        public string StandardTitle => "Восстановление доступа";

        public RestoreAccessControl()
        {
            InitializeComponent();

            DataContext = new RestoreAccessViewModel();
        }

        public RestoreAccessControl(string email)
        {
            InitializeComponent();

            DataContext = new RestoreAccessViewModel(email);
        }
    }
}
