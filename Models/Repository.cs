namespace WeatherApp.Models
{
    public static class Repository
    {
        public static List<Weather> Weathers
        {
            get
            {
                WeatherDbContext context = new WeatherDbContext();
                List<Weather> weathers = context.Weathers.ToList();
                return weathers;
            }
        }

        public static void AddWeather(Weather newWeather)
        {
            WeatherDbContext context = new WeatherDbContext();
            context.Weathers.Add(newWeather);
            context.SaveChanges();
        }

        public static void DeleteWeather(int weatherID)
        {
            WeatherDbContext context = new WeatherDbContext();
            List<Weather> weathers = context.Weathers.ToList();

            for (int i = 0; i < Weathers.Count; i++)
            {
                if (weatherID == weathers[i].WeatherID)
                {
                    context.Weathers.RemoveRange(weathers[i]);
                }
            }
            context.SaveChanges();
        }

        public static Weather AlterarWeather(Weather myWeather)
        {
            WeatherDbContext context = new WeatherDbContext();

            context.Weathers.Update(myWeather);

            context.SaveChanges();

            return myWeather;
        }


    }
}
