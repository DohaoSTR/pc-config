using PCConfig.Model.PcPartPicker;
using System.Windows;
using System.Windows.Controls;

namespace PCConfig.ViewModel.SideMenu.Tabs.Realizations.Products
{
    public class SpecificationItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate StandardSpecificationItem { get; set; }

        public DataTemplate SpecificationCategory { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (container is FrameworkElement element && item != null)
            {
                LongSpecification longSpecification = item as LongSpecification;

                if (longSpecification.LongSpecificationType == LongSpecificationType.Standard)
                {
                    return StandardSpecificationItem;
                }
                else if (longSpecification.LongSpecificationType == LongSpecificationType.Category)
                {
                    return SpecificationCategory;
                }
            }

            return null;
        }
    }
}
