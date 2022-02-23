using Microsoft.AspNetCore.Mvc;
using Microsoft.MovieBooking.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.MovieBooking.Controllers
{
    public class ConcertController : Controller
    {
        private  readonly ILogger<ConcertController> _logger;

        public ConcertController(ILogger<ConcertController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<ConcertViewModel> concertViewModel = null;
            HttpClient client = new HttpClient();
            //HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7232/api/Concert");
            HttpResponseMessage responseMessage = await client.GetAsync("https://microsoftmoviebookingconcertapi.azurewebsites.net/api/Concert");
            if (responseMessage != null && responseMessage.IsSuccessStatusCode)
            {
                concertViewModel = JsonSerializer.Deserialize<List<ConcertViewModel>>(responseMessage.Content.ReadAsStringAsync().Result);
            }
            return View(concertViewModel);
        }
    }
}
