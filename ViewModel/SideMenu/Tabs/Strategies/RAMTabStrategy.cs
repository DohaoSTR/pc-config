using PCConfig.Model.Contexts;
using PCConfig.View.Tabs.Products;
using PCConfig.ViewModel.SideMenu.Tabs.Realizations.Products;
using System.Windows.Controls;

namespace PCConfig.ViewModel.SideMenu.Tabs.Strategies
{
    public class RAMTabStrategy : ITabStrategy
    {
        public event Action<ProductsListItemViewModel> ProductItemClicked;

        public Control HandleTab(SideMenuItemViewModel item)
        {
            PCPartPickerContext context = new PCPartPickerContext();

            string partType = "memory";
            var parts = context.GetRAMShortData();

            ProductControl control = new ProductControl(partType, parts);
            control.ProductClicked += ProductItemClicked;

            return control;
        }
    }
}
