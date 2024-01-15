using Microsoft.EntityFrameworkCore;
using PCConfig.Model.Prices.Citilink;
using PCConfig.Model.Prices.DNS;

namespace PCConfig.Model.Contexts
{
    public class PricesContext : ApplicationContext
    {
        public DbSet<CitilinkAvailable> CitilinkAvailables { get; set; } = null!;
        public DbSet<CitilinkPrice> CitilinkPrices { get; set; } = null!;
        public DbSet<CitilinkProduct> CitilinkProducts { get; set; } = null!;

        public DbSet<DNSAvailable> DNSAvailables { get; set; } = null!;
        public DbSet<DNSPrice> DNSPrices { get; set; } = null!;
        public DbSet<DNSProduct> DNSProducts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            InitConnectionSettings("PricesConnectionSettings");

            optionsBuilder.UseMySql($"Host={ConnectionSettings.Host};Port={ConnectionSettings.Port};" +
                $"Database={ConnectionSettings.DatabaseName};Username={ConnectionSettings.Username};" +
                $"Password={ConnectionSettings.Password}",
                new MySqlServerVersion(new Version(8, 0, 34)));
        }

        public List<DNSPrice> GetMostActualDNSPrices()
        {
            string procedureName = "get_most_actual_dns_prices";
            List<DNSPrice> results = DNSPrices.FromSqlRaw($"CALL {procedureName}").ToList();

            return results;
        }

        public List<CitilinkPrice> GetMostActualCitilinkPrices()
        {
            string procedureName = "get_most_actual_citilink_prices";
            List<CitilinkPrice> results = CitilinkPrices.FromSqlRaw($"CALL {procedureName}").ToList();

            return results;
        }

        public List<DNSAvailable> GetMostActualDNSAvailable()
        {
            string procedureName = "get_most_actual_dns_available";
            List<DNSAvailable> results = DNSAvailables.FromSqlRaw($"CALL {procedureName}").ToList();

            return results;
        }

        public List<CitilinkAvailable> GetMostActualCitilinkAvailable()
        {
            string procedureName = "get_most_actual_citilink_available";
            List<CitilinkAvailable> results = CitilinkAvailables.FromSqlRaw($"CALL {procedureName}").ToList();

            return results;
        }

        public List<DNSProduct> GetDNSProductsWithoutRecord()
        {
            string procedureName = "get_dns_products_without_record";
            List<DNSProduct> results = DNSProducts.FromSqlRaw($"CALL {procedureName}").ToList();

            return results;
        }

        public List<CitilinkProduct> GetCitilinkProductsWithoutRecord()
        {
            string procedureName = "get_citilink_products_without_record";
            List<CitilinkProduct> results = CitilinkProducts.FromSqlRaw($"CALL {procedureName}").ToList();

            return results;
        }
    }
}