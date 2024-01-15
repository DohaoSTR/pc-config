using PCConfig.Model.UserBenchmark;
using System.Globalization;
using System.Windows.Data;

namespace PCConfig.Model.Converters
{
    public class ResolutionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Resolution resolution
                ? resolution switch
                {
                    Resolution.None => "Усредненное значение",
                    Resolution.HD => "HD",
                    Resolution.FullHD => "Full HD",
                    Resolution.QHD => "QHD",
                    Resolution.K4 => "4K",
                    _ => resolution.ToString(),
                }
                : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
