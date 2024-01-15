using PCConfig.Model.UserBenchmark;
using System.Globalization;
using System.Windows.Data;

namespace PCConfig.Model.Converters
{
    public class GameSettingsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is GameSettings gameSettings
                ? gameSettings switch
                {
                    GameSettings.None => "Усредненное значение",
                    GameSettings.Low => "Низкие",
                    GameSettings.Med => "Средние",
                    GameSettings.High => "Высокие",
                    GameSettings.Max => "Ультра",
                    _ => gameSettings.ToString(),
                }
                : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
