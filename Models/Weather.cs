using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApp.Models
{
    public class Weather
    {

        public int WeatherID { get; set; }

        public string? City { get; set; }


        [Required(ErrorMessage = "Please insert temperature")]
        public double Temperature { get; set; }

        [Required(ErrorMessage = "Please insert Date")]
        //[Column(TypeName = "Date")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string Date { get; set; }

    }
}
