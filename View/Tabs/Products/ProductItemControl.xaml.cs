using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
