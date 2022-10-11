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
                return View("WeatherAddedError",list);
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
            List<Weather> list = Repository.WeatherHistory(Date1,Date2, city);

            return View("WeatherHistoryResult", list);
        }

        [HttpPost]
        public IActionResult AverageWeather(string Date1, string Date2, string city)
        {
            double average = Repository.Average(Date1, Date2);
            string result = Convert.ToString(average);

            if (city == "Porto")
            {
                return View("AveragePorto", ViewBag.Average = result);
            }
            if (city == "lisboa")
            {
                return View("AverageLisboa", ViewBag.Average = result);
            }
            if (city == "Faro")
            {
                return View("AverageFaro", ViewBag.Average = result);
            }
            if (city == "Açores")
            {
                return View("AverageAçores", ViewBag.Average = result);
            }
            else 
            {
                return View("AverageMadeira", ViewBag.Average = result);
            }


        }


    }
}
