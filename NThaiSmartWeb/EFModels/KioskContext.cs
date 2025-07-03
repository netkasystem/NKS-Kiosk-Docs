using Microsoft.EntityFrameworkCore;

namespace NThaiSmartWeb.EFModels
{
    public class KioskContext : DBContext
    {
        private readonly IConfiguration _configuration;

        public KioskContext(DbContextOptions<KioskContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DbContextConfigHelper.ConfigureFromEnvOrAppSettings(optionsBuilder, _configuration);
        }
    }

    public static class DbContextConfigHelper
    {
        public static void ConfigureFromEnvOrAppSettings(this DbContextOptionsBuilder optionsBuilder, IConfiguration configuration)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var envConn = Environment.GetEnvironmentVariable("MYSQL_CONNECTION_STRING");
                var configConn = configuration.GetConnectionString("DefaultConnection");
                var connectionString = !string.IsNullOrWhiteSpace(envConn) ? envConn : configConn;

                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new InvalidOperationException("❌ ไม่พบ Connection String จาก ENV หรือ AppSettings");
                }

                var serverVersion = ServerVersion.AutoDetect(connectionString);
                optionsBuilder.UseMySql(connectionString, serverVersion);
            }
        }
    }
}