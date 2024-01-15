using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PCConfig.View
{
    /// <summary>
    /// Interaction logic for SideMenuControl.xaml
    /// </summary>
    public partial class SideMenuItemControl : UserControl
    {
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(SideMenuItemControl));

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(SideMenuItemControl));

        public string Text
        {
            get => MenuItemTextBlock.Text;
            set => MenuItemTextBlock.Text = value;
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(SideMenuItemControl),
                new PropertyMetadata(default(string),
                  (o, args) => ((SideMenuItemControl)o).Text = (string)args.NewValue)
               );

        public static readonly DependencyProperty KindProperty =
        DependencyProperty.Register("Kind", typeof(string), typeof(SideMenuItemControl));

        public string Kind
        {
            get => (string)GetValue(KindProperty);
            set => SetValue(KindProperty, value);
        }

        public SideMenuItemControl()
        {
            InitializeComponent();
        }
    }
}
