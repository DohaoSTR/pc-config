using Microsoft.EntityFrameworkCore;
using PCConfig.Model.Access;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Windows;

namespace PCConfig.Model.Contexts
{
    public class ApplicationContext : DbContext
    {
        protected ConnectionSettings ConnectionSettings;

        protected void InitConnectionSettings(string configSectionName)
        {
            ConfigurationManager manager = new();
            ConnectionSettings = manager.GetDatabaseConnectionSettings(configSectionName);
        }

        private static bool IsNetworkAvailable()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }

        public ApplicationContext()
        {
            try
            {
                if (!IsNetworkAvailable())
                {
                    MessageBox.Show("Отсутствует подключение к интернету.");
                }

                Database.EnsureCreated();
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка при подключении к бд!");
                //MessageBox.Show(e.Message.ToString());
            }
        }

        public void Add(Type entityType, object entity)
        {
            Type dbSetType = typeof(DbSet<>).MakeGenericType(entityType);
            object? dbSet = GetType()
                        .GetMethod("Set", new Type[] { })
                        .MakeGenericMethod(entityType)
                        .Invoke(this, null);

            dbSetType.GetMethod("Add").Invoke(dbSet, new[] { entity });
            SaveChanges();
        }

        public void Remove(Type entityType, object entity)
        {
            Type dbSetType = typeof(DbSet<>).MakeGenericType(entityType);

            object? dbSet = GetType()
                        .GetMethod("Set", new Type[] { })
                        .MakeGenericMethod(entityType)
                        .Invoke(this, null);

            dbSetType.GetMethod("Remove").Invoke(dbSet, new[] { entity });
            SaveChanges();
        }

        public void Update(Type entityType, object entity)
        {
            Type dbSetType = typeof(DbSet<>).MakeGenericType(entityType);

            object? dbSet = GetType()
            .GetMethod("Set", new Type[] { })
                            .MakeGenericMethod(entityType)
                            .Invoke(this, null);

            dbSetType.GetMethod("Update").Invoke(dbSet, new[] { entity });
            SaveChanges();
        }

        public IEnumerable<DataBaseEntity> GetAllEntities(Type entityType)
        {
            object? dbSet = GetType()
                            .GetMethod("Set", new Type[] { })
                            .MakeGenericMethod(entityType)
                            .Invoke(this, null);

            MethodInfo toListMethod = typeof(Enumerable)
                .GetMethod("ToList", BindingFlags.Static | BindingFlags.Public)
                .MakeGenericMethod(entityType);

            return (IEnumerable<DataBaseEntity>)toListMethod.Invoke(null, new[] { dbSet });
        }
    }
}