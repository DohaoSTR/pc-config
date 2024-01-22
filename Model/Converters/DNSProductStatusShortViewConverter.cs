using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PCConfig.Model.Converters
{
    public class DNSProductStatusShortViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "Нет в наличии";
            }
            else if ((value is string || value is int || value is double) && (value.ToString() == "0" || value.ToString() == ""))
            {
                return "Нет в наличии";
            }
            else
            {
                return "В наличии";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
