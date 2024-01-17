using System.Windows.Controls;

namespace PCConfig.View.Tabs.Products
{
    /// <summary>
    /// Interaction logic for ProductItemControl.xaml
    /// </summary>
    public partial class ProductItemControl : UserControl
    {
        public event Action<Type> Backed;

        private Type _tabType;

        public ProductItemControl(Type tabType)
        {
            InitializeComponent();

            _tabType = tabType;
        }

        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Backed?.Invoke(_tabType);
        }
    }
}
