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
                Repository.AddWeather(newWeather);
                List<Weather> list = Repository.LastTen();
                return View("WeatherAdded", list);
            }
            else 
                return View();
        }
    }
}
