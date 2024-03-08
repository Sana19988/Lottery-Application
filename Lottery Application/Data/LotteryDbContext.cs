using Lottery_Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Lottery_Application.Data;

public class LotteryDbContext : DbContext
{
    public DbSet<LotteryDraw> DrawHistory { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("LotteryDbConnection");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}


// provera za db?? 
/*public class LotteryDbContext : DbContext
    {
        public DbSet<LotteryDraw> DrawHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Server=localhost;Database=LotteryDB;Uid=root;Pwd=";

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("Connection string is not configured.");
                }

                try
                {
                    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Database connection error.", ex);
                }
            }
        }
    } 
 */