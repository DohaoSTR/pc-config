using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PCConfig.Model.UsersData;

namespace PCConfig.Model.Converters
{
    public class UserTypeDatabaseConverter : ValueConverter<UserType, string>
    {
        public UserTypeDatabaseConverter()
            : base(
                value => value.GetDatabaseValue(),
                value => EnumExtensions.ParseFromDatabaseValue<UserType>(value))
        {
        }
    }
}
