using System.Globalization;
using System.Windows.Data;

namespace PCConfig.Model.Converters
{
    public class PageIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is int pageIndex ? (pageIndex + 1).ToString() : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int pageIndex)
            {
                return (pageIndex - 1).ToString();
            }

            if (value is string pageIndexString)
            {
                try
                {
                    string pageNumber = (System.Convert.ToInt32(pageIndexString) - 1).ToString();
                    return pageNumber;
                }
                catch
                {
                    return value;
                }
            }

            return value;
        }
    }
}
