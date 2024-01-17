using PCConfig.Model.Contexts;
using PCConfig.View.Tabs.Products;
using PCConfig.ViewModel.SideMenu.Tabs.Realizations.Products;
using System.Windows.Controls;

namespace PCConfig.ViewModel.SideMenu.Tabs.Strategies
{
    public class CPUTabStrategy : ITabStrategy
    {
        public event Action<ProductsListItemViewModel, Type> ProductItemClicked;

        public Control HandleTab(SideMenuItemViewModel item)
        {
            PCPartPickerContext context = new PCPartPickerContext();

            string partType = "cpu";
            var parts = context.GetCPUShortData();

            ProductControl control = new ProductControl(partType, parts, typeof(CPUTabStrategy));
            control.ProductClicked += ProductItemClicked;

            return control;
        }
    }
}
