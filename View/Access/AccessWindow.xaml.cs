using PCConfig.ViewModel.Access;
using System.Windows;

namespace PCConfig.View
{
    /// <summary>
    /// Interaction logic for AccessWindow.xaml
    /// </summary>
    public partial class AccessWindow : Window
    {
        public AccessWindow()
        {
            InitializeComponent();

            AccessControlManager manager = new();
            manager.Closed += Manager_Closed;
            DataContext = manager;
        }

        private void Manager_Closed()
        {
            Close();
        }
    }
}