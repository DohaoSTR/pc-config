using PCConfig.Model.Contexts;
using PCConfig.View.Tabs.Products;
using PCConfig.ViewModel.SideMenu.Tabs.Realizations.Products;
using System.Windows.Controls;

namespace PCConfig.ViewModel.SideMenu.Tabs.Strategies
{
    public class SSDTabStrategy : ITabStrategy
    {
        public event Action<ProductsListItemViewModel, Type> ProductItemClicked;

        public Control HandleTab(SideMenuItemViewModel item)
        {
            PCPartPickerContext context = new PCPartPickerContext();

            string partType = "ssd";
            var parts = context.GetSSDShortData();

            ProductControl control = new ProductControl(partType, parts, typeof(SSDTabStrategy));
            control.ProductClicked += ProductItemClicked;

            return control;
        }
    }
}
