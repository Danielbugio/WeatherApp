using Microsoft.EntityFrameworkCore;

namespace WeatherApp.Models
{
    public class WeatherDbContext: DbContext
    {
        public DbSet<Weather> Weathers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection =
            @"Server=(localdb)\mssqllocaldb;Database=WeatherApp;
        Trusted_Connection=True;";
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connection);
        }
    }

   
}
