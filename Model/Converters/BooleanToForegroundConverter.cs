using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace PCConfig.Model.Converters
{
    public class BooleanToForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool boolValue
                ? boolValue ? (Brush)new BrushConverter().ConvertFrom("#ffffff") : (Brush)new BrushConverter().ConvertFrom("#6c7682")
                : (object?)(Brush)new BrushConverter().ConvertFrom("#6c7682");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
