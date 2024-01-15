using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;
using System.Diagnostics;

namespace PCConfig.Model.Contexts
{
    public class ConfigureContext : ApplicationContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            InitConnectionSettings("ConfigureConnectionSettings");

            optionsBuilder.UseMySql($"Host={ConnectionSettings.Host};Port={ConnectionSettings.Port};" +
                $"Database={ConnectionSettings.DatabaseName};Username={ConnectionSettings.Username};" +
                $"Password={ConnectionSettings.Password}",
                new MySqlServerVersion(new Version(8, 0, 34)));
        }

        // доделать
        public List<(PcPartPicker.Entities.Part, UserBenchmark.Entities.Part)> GetMostRecentPrices()
        {
            using MySqlConnection connection = new($"Host={ConnectionSettings.Host};Port={ConnectionSettings.Port};" +
                $"Database={ConnectionSettings.DatabaseName};Username={ConnectionSettings.Username};" +
                $"Password={ConnectionSettings.Password}");
            connection.Open();

            int index = 0;
            using (MySqlCommand command = new("get_compatible_parts", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Debug.WriteLine(reader["name"]);
                }
            }

            Debug.WriteLine(index);

            return null;
        }
    }
}
