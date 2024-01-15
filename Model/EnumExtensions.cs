using System.Reflection;

namespace PCConfig.Model
{
    public static class EnumExtensions
    {
        public static string GetDatabaseValue(this Enum value)
        {
            DatabaseValueAttribute? attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttribute<DatabaseValueAttribute>();

            return attribute?.Value;
        }

        public static TEnum ParseFromDatabaseValue<TEnum>(string value)
            where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .FirstOrDefault(v => v.GetDatabaseValue() == value);
        }
    }
}
