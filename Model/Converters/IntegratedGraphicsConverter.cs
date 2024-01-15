using System.Globalization;
using System.Windows.Data;

namespace PCConfig.Model.Converters
{
    public class IntegratedGraphicsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string integratedGraphics = (string)value;

                return integratedGraphics;
            }

            return "нет";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
