using PCConfig.Model.UserBenchmark;
using System.Globalization;
using System.Windows.Data;

namespace PCConfig.Model.Converters
{
    public class GameSettingsToDisplayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is GameSettings enumValue)
            {
                return ConvertEnumToDisplay(enumValue);
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        private string ConvertEnumToDisplay(GameSettings enumValue)
        {
            switch (enumValue)
            {
                case GameSettings.Low:
                    return "Низкие";
                case GameSettings.Med:
                    return "Средние";
                case GameSettings.High:
                    return "Высокие";
                case GameSettings.Max:
                    return "Ультра";
                case GameSettings.None:
                    return "Усредненное значение";
            }

            return enumValue.ToString();
        }
    }
}
