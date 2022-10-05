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
                return View("WeatherAdded", newWeather);
            }
            else 
                return View();
        }
    }
}
