using System.Globalization;
using System.Windows.Data;

namespace PCConfig.Model.Converters
{
    public class DNSProductStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "отсутствует";
            }
            else if ((value is string || value is int || value is double) && (value.ToString() == "0" || value.ToString() == ""))
            {
                return "отсутствует";
            }
            else
            {
                return "в наличии";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
