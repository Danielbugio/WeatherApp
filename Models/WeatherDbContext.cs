using Microsoft.EntityFrameworkCore;

namespace WeatherApp.Models
{
    public class WeatherDbContext : DbContext
    {
        public DbSet<Weather> Weathers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection =
            @"Server=(localdb)\mssqllocaldb;Database=WeatherApp;
        Trusted_Connection=True;";
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //create managers and products
            Weather weather1 = new Weather
            {
                WeatherID = -1,
                City = "Lisboa",
                Temperature = 12,
                Date = "2022-10-01"
            };

            Weather weather2 = new Weather
            {
                WeatherID = -2,
                City = "Lisboa",
                Temperature = 14,
                Date = "2022-10-02"
            };

            Weather weather3 = new Weather
            {
                WeatherID = -3,
                City = "Lisboa",
                Temperature = 16,
                Date = "2022-10-03"
            };

            Weather weather4 = new Weather
            {
                WeatherID = -4,
                City = "Lisboa",
                Temperature = 18,
                Date = "2022-10-04"
            };

            Weather weather5 = new Weather
            {
                WeatherID = -5,
                City = "Lisboa",
                Temperature = 14,
                Date = "2022-10-05"
            };

            Weather weather6 = new Weather
            {
                WeatherID = -6,
                City = "Lisboa",
                Temperature = 6,
                Date = "2022-10-06"
            };

            Weather weather7 = new Weather
            {
                WeatherID = -7,
                City = "Lisboa",
                Temperature = 11,
                Date = "2022-10-07"
            };

            Weather weather8 = new Weather
            {
                WeatherID = -8,
                City = "Lisboa",
                Temperature = 22,
                Date = "2022-10-08"
            };

            builder.Entity<Weather>().HasData(weather1);
            builder.Entity<Weather>().HasData(weather2);
            builder.Entity<Weather>().HasData(weather3);
            builder.Entity<Weather>().HasData(weather4);
            builder.Entity<Weather>().HasData(weather5);
            builder.Entity<Weather>().HasData(weather6);
            builder.Entity<Weather>().HasData(weather7);
            builder.Entity<Weather>().HasData(weather8);





        }


    }
}
