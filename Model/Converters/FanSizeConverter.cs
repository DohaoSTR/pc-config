using System.Globalization;
using System.Windows.Data;

namespace PCConfig.Model.Converters
{
    public class FanSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                double size = (double)value;
                double halfSize = size / 2;

                return $"{halfSize} x {halfSize}";
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
