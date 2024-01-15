using System.Windows;
using System.Windows.Controls;

namespace PCConfig.ViewModel.SideMenu.Templates
{
    public class TopSideMenuItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DropOutSideMenuItem { get; set; }

        public DataTemplate StandardSideMenuItem { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (container is FrameworkElement element && item != null)
            {
                Type type = item.GetType();

                if (type == typeof(SideMenuItemViewModel))
                {
                    SideMenuItemViewModel model = item as SideMenuItemViewModel;
                    return model.LocationType == SideMenuItemLocationType.Top ? StandardSideMenuItem : TemplateSelectorHelper.InvisibleTemplate;
                }
                else if (type == typeof(DropOutSideMenuItemViewModel))
                {
                    DropOutSideMenuItemViewModel model = item as DropOutSideMenuItemViewModel;
                    return model.LocationType == SideMenuItemLocationType.Top ? DropOutSideMenuItem : TemplateSelectorHelper.InvisibleTemplate;
                }
            }

            return TemplateSelectorHelper.InvisibleTemplate;
        }
    }
}
