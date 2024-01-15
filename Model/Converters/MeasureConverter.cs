using System.Globalization;
using System.Windows.Data;

namespace PCConfig.Model.Converters
{
    public class MeasureConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string valueString = (string)value;

                if (valueString == "GB")
                {
                    return "ГБ";
                }
                else if (valueString == "MB")
                {
                    return "МБ";
                }
                else if (valueString == "TB")
                {
                    return "ТБ";
                }
            }

            return "ГБ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
