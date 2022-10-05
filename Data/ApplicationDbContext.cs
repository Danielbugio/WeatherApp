using Microsoft.EntityFrameworkCore;
using WeatherApp.Models;

namespace WeatherApp.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Weather> Weathers { get; set; }
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connection = @"Server=(localdb)\mssqllocaldb;Database=WeatherApp; Trusted_Connection=True;";
        optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connection);
    }


}
