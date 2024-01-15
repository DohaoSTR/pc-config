using System.Globalization;
using System.Windows.Data;

namespace PCConfig.Model.Converters
{
    public class ProductsCategoryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string productCategory = (string)value;

                switch (productCategory)
                {
                    case "cpu":
                        return "Процессоры";
                    case "cpu-cooler":
                        return "Кулеры для процессоров";
                    case "video-card":
                        return "Видеокарты";
                    case "memory":
                        return "Оперативная память";
                    case "motherboard":
                        return "Материнские платы";
                    case "ssd":
                        return "Твердотельные накопители (SSD)";
                    case "hdd":
                        return "Жесткие диски";
                    case "hybrid-storage":
                        return "Гибридные накопители";
                    case "case-fan":
                        return "Охлаждение компьютера";
                    case "case":
                        return "Корпуса";
                    case "power-supply":
                        return "Блоки питания";
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
