using System.Globalization;
using System.Windows.Data;

namespace PCConfig.Model.Converters
{
    public class RoleNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string roleName = (string)value;

                if (roleName == "StandardUser")
                {
                    return "Пользователь";
                }
                else if (roleName == "Admin")
                {
                    return "Админ";
                }
                else if (roleName == "Moderator")
                {
                    return "Модератор";
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
