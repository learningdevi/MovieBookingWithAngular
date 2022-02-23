using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.MovieBooking.Concert.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.MovieBooking.Concert.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcertController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public ConcertController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                List<ConcertModel> concertModels = await GetAllConcertsAsync();
                var concerts = JsonSerializer.Serialize(concertModels);
                return Ok(concerts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        internal async Task<List<ConcertModel>> GetAllConcertsAsync()
        {
            return new List<ConcertModel>
            {
                new ConcertModel()
                {
                    Id = 1,
                    Name = "BollywoodNight",
                    ShowDate = DateTime.Now,
                    ShowTime = "9:00 PM"
                },
                new ConcertModel()
                {
                    Id=2,
                    Name ="Dhvani",
                    ShowDate= DateTime.Now,
                    ShowTime="6:00 PM"
                },
                new ConcertModel()
                {
                    Id=3,
                    Name ="Ekatvam",
                    ShowDate=   DateTime.Now.AddDays(1),
                    ShowTime="9:00 PM"
                },
                new ConcertModel()
                {
                    Id =4,
                    Name ="Mars",
                    ShowDate=DateTime.Now.AddDays(1),
                    ShowTime = "6:00 PM"
                },
                new ConcertModel()
                {
                    Id=5,
                    Name ="Souvenir",
                    ShowDate = DateTime.Now.AddDays(1),
                    ShowTime = "10:00 PM"
                }
            };
        }
    }
}
