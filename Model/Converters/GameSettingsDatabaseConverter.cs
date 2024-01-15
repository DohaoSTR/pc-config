using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PCConfig.Model.UserBenchmark;

namespace PCConfig.Model.Converters
{
    public class GameSettingsDatabaseConverter : ValueConverter<GameSettings, string>
    {
        public GameSettingsDatabaseConverter()
            : base(
                value => value.GetDatabaseValue(),
                value => EnumExtensions.ParseFromDatabaseValue<GameSettings>(value))
        {
        }
    }
}
