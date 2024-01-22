using PCConfig.ViewModel.SideMenu.Tabs.Realizations.GenerationModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace PCConfig.View.Tabs.GenerationModel
{
    /// <summary>
    /// Interaction logic for GenerationModelControl.xaml
    /// </summary>
    public partial class GenerationModelControl : UserControl
    {
        public GenerationModelControl()
        {
            InitializeComponent();

            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo parentDirectory = Directory.GetParent(currentDirectory);
            string parentPath = parentDirectory.FullName;

            string gamingPath = Path.Combine(parentPath, "Gaming_128.png");
            string desktopPath = Path.Combine(parentPath, "Desktop_128.png");
            string serverPath = Path.Combine(parentPath, "Workstation_128.png");

            string combineGamingPath = Path.Combine(currentDirectory, gamingPath);
            string combineDesktopPath = Path.Combine(currentDirectory, desktopPath);
            string combineServerPath = Path.Combine(currentDirectory, serverPath);

            GameImage.Source = new BitmapImage(new Uri(combineGamingPath));
            DesktopImage.Source = new BitmapImage(new Uri(combineDesktopPath));
            ServerImage.Source = new BitmapImage(new Uri(combineServerPath));

            GenerationViewModel model = new GenerationViewModel();
            DataContext = model;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии ссылки: {ex.Message}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (infoPopup.IsOpen)
            {
                infoPopup.IsOpen = false;
            }
            else
            {
                infoPopup.PlacementTarget = (UIElement)sender;
                infoPopup.IsOpen = true;
            }
        }

    }
}