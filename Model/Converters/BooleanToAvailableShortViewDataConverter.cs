using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PCConfig.Model.Converters
{
    public class BooleanToAvailableShortViewDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "Нет в наличии";
            }
            else
            {
                bool booleanValue = (bool)value;

                if (booleanValue == false)
                {
                    return "Нет в наличии";
                }
                else
                {
                    return "В наличии";
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
