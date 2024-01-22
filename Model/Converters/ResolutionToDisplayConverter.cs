using PCConfig.Model.UserBenchmark;
using System.Globalization;
using System.Windows.Data;

namespace PCConfig.Model.Converters
{
    public class ResolutionToDisplayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Resolution enumValue)
            {
                return ConvertEnumToDisplay(enumValue);
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        private string ConvertEnumToDisplay(Resolution enumValue)
        {
            switch (enumValue)
            {
                case Resolution.HD:
                    return "HD";
                case Resolution.QHD:
                    return "QHD";
                case Resolution.FullHD:
                    return "Full HD";
                case Resolution.K4:
                    return "4K";
                case Resolution.None:
                    return "Усредненное значение";
            }

            return enumValue.ToString();
        }
    }
}
