using Microsoft.EntityFrameworkCore;
using PCConfig.Model.Converters;
using PCConfig.Model.UserBenchmark;
using PCConfig.Model.UserBenchmark.Entities;

namespace PCConfig.Model.Contexts
{
    public class UserBenchmarkContext : ApplicationContext
    {
        public DbSet<FPSData> FPSDatas { get; set; } = null!;
        public DbSet<GameImage> GameImages { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Metrics> Metrics { get; set; } = null!;

        public DbSet<Part> Parts { get; set; } = null!;
        public DbSet<PartUserData> PartUserDatas { get; set; } = null!;

        public DbSet<PartCompareKey> PartsCompareKeys { get; set; } = null!;
        public DbSet<PartKey> PartsKeys { get; set; } = null!;

        public DbSet<CPUMetricsData> CPUMetricsDatas { get; set; } = null!;
        public DbSet<GPUMetricsData> GPUMetricsDatas { get; set; } = null!;
        public DbSet<HDDMetricsData> HDDMetricsDatas { get; set; } = null!;
        public DbSet<RAMMetricsData> RAMMetricsDatas { get; set; } = null!;
        public DbSet<SSDMetricsData> SSDMetricsDatas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            InitConnectionSettings("UserBenchmarkConnectionSettings");

            optionsBuilder.UseMySql($"Host={ConnectionSettings.Host};Port={ConnectionSettings.Port};" +
                $"Database={ConnectionSettings.DatabaseName};Username={ConnectionSettings.Username};" +
                $"Password={ConnectionSettings.Password}",
                new MySqlServerVersion(new Version(8, 0, 34)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FPSData>(entity =>
            {
                entity.HasIndex(e => e.Id).IsUnique();
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasIndex(e => e.Key).IsUnique();
                entity.HasIndex(e => e.Name).IsUnique();
            });

            modelBuilder
            .Entity<FPSData>()
            .Property(e => e.Resolution)
            .HasConversion(new ResolutionDatabaseConverter());

            modelBuilder
            .Entity<FPSData>()
            .Property(e => e.GameSettings)
            .HasConversion(new GameSettingsDatabaseConverter());
        }

        public IEnumerable<Game> GetGames()
        {
            IEnumerable<Game> result = Games.Where(g => FPSDatas.Any(fd => fd.GameKey == g.Key));

            return result.ToList();
        }

        public IEnumerable<FPSDataWithModels> GetFPSDataByGameName(string gameName)
        {
            IEnumerable<FPSDataWithModels> result = from fps in FPSDatas
                                                    join game in Games
                                                    on new { fps.GameKey, GameName = gameName }
                                                    equals new { GameKey = game.Key, GameName = game.Name }
                                                    join cpu in Parts on fps.CpuId equals cpu.Id into cpuGroup
                                                    from cpu in cpuGroup.DefaultIfEmpty()
                                                    join gpu in Parts on fps.GpuId equals gpu.Id into gpuGroup
                                                    from gpu in gpuGroup.DefaultIfEmpty()
                                                    select new FPSDataWithModels
                                                    {
                                                        FPS = fps.FPS,
                                                        Samples = fps.Samples,
                                                        Resolution = fps.Resolution,
                                                        GameSettings = fps.GameSettings,
                                                        CPUModel = cpu != null ? cpu.Model : null,
                                                        GPUModel = gpu != null ? gpu.Model : null
                                                    };

            return result.ToList();
        }

        public IEnumerable<GameWithTotalSamples> GetGamesWithTotalSamples()
        {
            IQueryable<GameWithTotalSamples> result = from fps in FPSDatas
                                                      join game in Games on fps.GameKey equals game.Key
                                                      join game_image in GameImages on game.Key equals game_image.GameKey
                                                      group fps.Samples by new { game.Name, game.Key, game_image.ImageLink } into grouped
                                                      where grouped.Sum() > 0
                                                      select new GameWithTotalSamples
                                                      {
                                                          Name = grouped.Key.Name,
                                                          Key = grouped.Key.Key,
                                                          ImageLink = grouped.Key.ImageLink,
                                                          TotalSamples = grouped.Sum()
                                                      };

            return result.ToList();
        }
    }
}
