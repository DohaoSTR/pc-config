using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PCConfig.Model.Converters
{
    public class NameToMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string name && name.Equals("Характеристики комплектующей", StringComparison.OrdinalIgnoreCase))
            {
                return new Thickness(0, 0, 20, 0);
            }
            else
            {
                return new Thickness(0, 30, 20, 0);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
