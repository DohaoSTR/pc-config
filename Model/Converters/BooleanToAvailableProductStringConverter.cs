using System.Globalization;
using System.Windows.Data;

namespace PCConfig.Model.Converters
{
    public class BooleanToAvailableProductStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "отсутствует";
            }
            else
            {
                bool booleanValue = (bool)value;

                if (booleanValue == false)
                {
                    return "отсутствует";
                }
                else
                {
                    return "в наличии";
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
