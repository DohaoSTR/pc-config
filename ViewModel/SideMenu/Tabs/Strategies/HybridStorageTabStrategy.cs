using PCConfig.Model.Contexts;
using PCConfig.View.Tabs.Products;
using PCConfig.ViewModel.SideMenu.Tabs.Realizations.Products;
using System.Windows.Controls;

namespace PCConfig.ViewModel.SideMenu.Tabs.Strategies
{
    public class HybridStorageTabStrategy : ITabStrategy
    {
        public event Action<ProductsListItemViewModel> ProductItemClicked;

        public Control HandleTab(SideMenuItemViewModel item)
        {
            PCPartPickerContext context = new PCPartPickerContext();

            string partType = "hybrid-storage";
            var parts = context.GetHybridStorageShortData();

            ProductControl control = new ProductControl(partType, parts);
            control.ProductClicked += ProductItemClicked;

            return control;
        }
    }
}
