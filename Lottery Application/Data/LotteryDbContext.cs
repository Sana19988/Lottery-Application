using Lottery_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Lottery_Application.Data;

public class LotteryDbContext : DbContext
{
    public DbSet<LotteryDraw> DrawHistory { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = "Server=.\\SQLEXPRESS;Database=lotteryDB;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}