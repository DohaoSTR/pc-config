using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PCConfig.Model.UserBenchmark;

namespace PCConfig.Model.Converters
{
    public class ResolutionDatabaseConverter : ValueConverter<Resolution, string>
    {
        public ResolutionDatabaseConverter()
            : base(
                value => value.GetDatabaseValue(),
                value => EnumExtensions.ParseFromDatabaseValue<Resolution>(value))
        {
        }
    }
}
