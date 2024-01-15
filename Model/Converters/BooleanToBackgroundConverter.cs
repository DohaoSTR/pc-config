using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace PCConfig.Model.Converters
{
    public class BooleanToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool boolValue
                ? boolValue ? (Brush)new BrushConverter().ConvertFrom("#7950f2") : Brushes.Transparent
                : (object?)(Brush)new BrushConverter().ConvertFrom("#7950f2");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
