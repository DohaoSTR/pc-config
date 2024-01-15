using PCConfig.Model.UsersData;
using System.Globalization;
using System.Windows.Data;

namespace PCConfig.Model.Converters
{
    public class UserTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                UserType userType = (UserType)value;

                if (userType == UserType.Google)
                {
                    return "С помощью Google";
                }
                else if (userType == UserType.Standard)
                {
                    return "С помощью PCConfigurator";
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}