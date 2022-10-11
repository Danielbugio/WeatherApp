using System.Security.Cryptography.X509Certificates;

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


        
        public static bool AddWeather(Weather newWeather)
        {
            WeatherDbContext context = new WeatherDbContext();
            foreach (Weather weather in Weathers)
            {
                if (newWeather.Date == weather.Date && newWeather.City == weather.City)
                { return false; }
            }
            context.Weathers.Add(newWeather);
            context.SaveChanges();
            return true;
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

        public static List<Weather> LastTen()
        {
            List<Weather> weatherList = new List<Weather>();

            if(Weathers.Count<10)
            {
                weatherList = Weathers;
            }
            else
            {
                for (int i = (Weathers.Count-10); i < Weathers.Count; i++)
                    weatherList.Add(Weathers[i]);
            }
            return weatherList;
        }

        public static double Average(string StartDate, string EndDate, string city)
        {
            DateTime firstDate = Convert.ToDateTime(StartDate);
            DateTime lastDate = Convert.ToDateTime(EndDate);

            WeatherDbContext context = new WeatherDbContext();
            List<Weather> weathers = context.Weathers.ToList();

            double average = 0;
            double total = 0;
            int count = 0;

            foreach ( Weather weather in weathers )
            {
                if (Convert.ToDateTime(weather.Date) >= firstDate && Convert.ToDateTime(weather.Date)<= lastDate && weather.City == city)
                {
                   
                    total = total + weather.Temperature;
                    count=count+1;
                    average=total/count;

                }
            }           

            return average;
        }

        public static double MinWeather(string StartDate, string EndDate, string city)
        { 
            DateTime firstDate = Convert.ToDateTime(StartDate);
            DateTime lastDate = Convert.ToDateTime(EndDate);
            double minWeather = 500;

            WeatherDbContext context = new WeatherDbContext();
            List<Weather> weathers = context.Weathers.ToList();
                        
            foreach (Weather weather in weathers)
            {
                if (Convert.ToDateTime(weather.Date) >= firstDate && Convert.ToDateTime(weather.Date) <= lastDate && weather.Temperature< minWeather && weather.City == city)
                {

                    minWeather = weather.Temperature;

                }
            }

            return minWeather;
        }

        public static double MaxWeather(string StartDate, string EndDate, string city)
        {
            DateTime firstDate = Convert.ToDateTime(StartDate);
            DateTime lastDate = Convert.ToDateTime(EndDate);
            double maxWeather = -500;

            WeatherDbContext context = new WeatherDbContext();
            List<Weather> weathers = context.Weathers.ToList();

            foreach (Weather weather in weathers)
            {
                if (Convert.ToDateTime(weather.Date) >= firstDate && Convert.ToDateTime(weather.Date) <= lastDate && weather.Temperature > maxWeather && weather.City==city)
                {

                    maxWeather = weather.Temperature;

                }
            }

            return maxWeather;
        }

        public static List<Weather> WeatherHistory(string StartDate, string EndDate, string city)
        {
            DateTime firstDate = Convert.ToDateTime(StartDate);
            DateTime lastDate = Convert.ToDateTime(EndDate);

            WeatherDbContext context = new WeatherDbContext();
            List<Weather> weathers = context.Weathers.ToList();
            List<Weather> weathersHistory = new List<Weather>();

            foreach (Weather weather in weathers)
            {
                if(weather.City==city)
                {
                    if(Convert.ToDateTime(weather.Date) >= firstDate && Convert.ToDateTime(weather.Date) <= lastDate)
                    {
                        weathersHistory.Add(weather);
                    }
                }
            }

            return weathersHistory;

        }


    }
}
