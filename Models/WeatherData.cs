namespace WeatherApp.Models
{
    public class WeatherData
    {

        public double WeatherAverage { get; set; }
        public double WeatherMax { get; set; }

        public double WeatherMin { get; set; }

        public string? InitialDate { get; set; }

        public string? EndDate { get; set; }
        public string? City { get; set; }
    }
}
