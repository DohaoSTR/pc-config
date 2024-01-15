using System.Windows;

namespace PCConfig.ViewModel.SideMenu.Templates
{
    public static class TemplateSelectorHelper
    {
        public static readonly DataTemplate InvisibleTemplate = new()
        {
            VisualTree = new FrameworkElementFactory(typeof(FrameworkElement)),
            Triggers =
            {
                new Trigger
                {
                    Property = UIElement.VisibilityProperty,
                    Value = Visibility.Collapsed
                }
            }
        };
    }
}
