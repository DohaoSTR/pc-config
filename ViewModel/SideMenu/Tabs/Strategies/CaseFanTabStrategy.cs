using PCConfig.Model.Contexts;
using PCConfig.View.Tabs.Products;
using PCConfig.ViewModel.SideMenu.Tabs.Realizations.Products;
using System.Windows.Controls;

namespace PCConfig.ViewModel.SideMenu.Tabs.Strategies
{
    public class CaseFanTabStrategy : ITabStrategy
    {
        public event Action<ProductsListItemViewModel, Type> ProductItemClicked;

        public Control HandleTab(SideMenuItemViewModel item)
        {
            PCPartPickerContext context = new PCPartPickerContext();

            string partType = "case-fan";
            var parts = context.GetCaseFanShortData();

            ProductControl control = new ProductControl(partType, parts, typeof(CaseFanTabStrategy));
            control.ProductClicked += ProductItemClicked;

            return control;
        }
    }
}
