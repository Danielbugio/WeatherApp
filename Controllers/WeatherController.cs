using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;


namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult InsertWeather()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertWeather(Weather newWeather)
        {
            if (ModelState.IsValid)
            {
                List<Weather> list = Repository.LastTen();
                if (Repository.AddWeather(newWeather))
                {
                    List<Weather> list1 = Repository.LastTen();
                    return View("WeatherAdded", list1);

                }
                return View("WeatherAddedError", list);
            }
            else
                return View();
        }

        [HttpGet]
        public IActionResult WeatherHistory()
        {


            return View();
        }

        [HttpPost]
        public IActionResult WeatherHistory(string Date1, string Date2, string city)
        {
            List<Weather> list = Repository.WeatherHistory(Date1, Date2, city);

            return View("WeatherHistoryResult", list);
        }

        [HttpGet]
        public IActionResult AverageWeather()
        {
            return View("AverageWeatherSelect");
        }

        //[HttpPost]
        public IActionResult DeleteWeather(int ID)
        {
            Repository.DeleteWeather(ID);
            return View("WeatherDeleted");
        }

        [HttpPost]
        public IActionResult AverageWeather(string Date1, string Date2, string city)
        {
            double average = Repository.Average(Date1, Date2, city);
            string result = Convert.ToString(average);

            WeatherData weatherData = new WeatherData();

            weatherData.City = city;
            weatherData.InitialDate = Date1;
            weatherData.EndDate = Date2;
            weatherData.WeatherMin = Repository.MinWeather(Date1, Date2, city);
            weatherData.WeatherMax = Repository.MaxWeather(Date1, Date2, city);
            weatherData.WeatherAverage = average;

            return View("AverageWeather", weatherData);

        }

        [HttpGet]
        public IActionResult WeatherUpdate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WeatherUpdate(Weather weatherData)
        {
            ViewBag.result = "Temperature Updated";
            if(Repository.UpdaterWeather(weatherData)==null)
            {
                ViewBag.result = "The temperature has not been updated, there are no records yet for the selected date and city.";
                return View("WeatherUpdated", weatherData);
            }
            else 
            {
                return View("WeatherUpdated", weatherData);
            }
        }


    }
}
