using System.Windows.Controls;

namespace PCConfig.View.Tabs.Products
{
    /// <summary>
    /// Interaction logic for ProductItemControl.xaml
    /// </summary>
    public partial class ProductItemControl : UserControl
    {
        public event Action Backed;

        public ProductItemControl()
        {
            InitializeComponent();
        }
    }
}
