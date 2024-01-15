using System.Globalization;
using System.Windows.Data;

namespace PCConfig.Model.Converters
{
    public class YesNoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string valueString = (string)value;

                if (valueString == "Yes")
                {
                    return "есть";
                }
                else if (valueString == "No")
                {
                    return "нету";
                }
            }

            return "нету";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
