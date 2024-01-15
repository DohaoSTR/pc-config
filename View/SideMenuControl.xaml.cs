using PCConfig.ViewModel.SideMenu;
using System.Windows;
using System.Windows.Controls;

namespace PCConfig.View
{
    /// <summary>
    /// Interaction logic for MenuControl.xaml
    /// </summary>
    public partial class SideMenuControl : UserControl
    {
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(SideMenuControl));

        public string Kind
        {
            get => (string)GetValue(KindProperty);
            set => SetValue(KindProperty, value);
        }

        public static readonly DependencyProperty KindProperty =
        DependencyProperty.Register("Kind", typeof(string), typeof(SideMenuControl));

        public IEnumerable<ISideMenuItem> SideMenuItems
        {
            get => (IEnumerable<ISideMenuItem>)GetValue(SideMenuItemsProperty);
            set => SetValue(SideMenuItemsProperty, value);
        }

        public static readonly DependencyProperty SideMenuItemsProperty =
        DependencyProperty.Register("SideMenuItems", typeof(IEnumerable<ISideMenuItem>), typeof(SideMenuControl));

        public SideMenuControl()
        {
            InitializeComponent();
        }
    }
}