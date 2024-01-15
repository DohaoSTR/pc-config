using System.Globalization;
using System.Windows.Data;

namespace PCConfig.Model.Converters
{
    public class IntToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value == 0 ? string.Empty : (object?)(value?.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is string stringValue && int.TryParse(stringValue, out int result) ? result : (object)0;
        }
    }
}