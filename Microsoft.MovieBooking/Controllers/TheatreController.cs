/*
 * Copyright - Microsoft
 */
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Core.BookingService;
using Microsoft.Core.Repository.Models;
using Microsoft.MovieBooking.Models;

namespace Microsoft.MovieBooking.Controllers
{
    /// <summary>
    /// This controller helps to process request.
    /// </summary>
    public class TheatreController : Controller
    {
        private readonly ILogger<MovieController> logger;
        private readonly IMapper mapper;
        private readonly ITheatreShowService theatreShowService;
        public TheatreController(ILogger<MovieController> logger, IMapper mapper, ITheatreShowService theatreShowService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.theatreShowService = theatreShowService;
        }

        /// <summary>
        /// Shows action method to display all the shows.
        /// </summary>
        /// <param name="Id">Represents movie id</param>
        /// <returns>Returns <see cref="ActionResult"/>.</returns>
        public IActionResult Shows(int Id)
        {
            DateTime showDate = new DateTime(2022, 1, 15);
            ShowsViewModel showsViewModel = new()
            {
                ShowsMappers = this.theatreShowService.GetShowsByMovie(Id, showDate),
                SeatMappers = new List<SeatMapper>(),
            };
            ViewBag.HideSeats = true;
            return View(showsViewModel);
        }

        /// <summary>
        /// SeatMapper action method.
        /// </summary>
        /// <param name="TheatreId">Represents theatre id.</param>
        /// <param name="ShowTimingsId">Represents show timings id.</param>
        /// <param name="MovieId">Represents movie id.</param>
        /// <param name="ShowMapperId">Represents show mapper id.</param>
        /// <returns>Returns <see cref="ActionResult"/>.</returns>
        public IActionResult SeatMapper(int TheatreId, int ShowTimingsId, int MovieId, int ShowMapperId)
        {
            DateTime showDate = new DateTime(2022, 1, 15);
            ShowsViewModel showsViewModel = new()
            {
                ShowsMappers = this.theatreShowService.GetShowsByMovie(MovieId, showDate),
                SeatMappers = this.theatreShowService.GetSeatMapper(TheatreId, showDate, ShowTimingsId)
            };
            ViewBag.HideSeats = false;
            ViewBag.ShowMapperId = ShowMapperId;
            return View("Shows", showsViewModel);
        }

        /// <summary>
        /// Book action method to book show.
        /// </summary>
        /// <param name="selectedSeats">Represents selected seats.</param>
        /// <param name="ShowMapperId">Represents show id.</param>
        /// <returns>Returns <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public IActionResult Book(string selectedSeats, string ShowMapperId)
        {
            List<BookingHistory> bookingHistories = ConstructBookingHistory(selectedSeats, ShowMapperId);
            this.theatreShowService.BookShow(bookingHistories);
            return View();
        }

        private List<BookingHistory> ConstructBookingHistory(string selectedSeats, string ShowMapperId)
        {
            List<BookingHistory> bookingHistories = new List<BookingHistory>();
            string[] seats = selectedSeats.Split(',');
            for (int i = 0; i < seats.Length; i++)
            {
                if (Convert.ToInt32(seats[i]) > 0)
                {
                    BookingHistory bookingHistory = new()
                    {
                        CustomerId = 1,
                        BookingDate = DateTime.Now,
                        MovieShowDate = new DateTime(2022, 1, 15),
                        ShowsMapperId = Convert.ToInt32(ShowMapperId),
                        SeatMapperId = Convert.ToInt32(seats[i]),
                        BookingStatus = 1
                    };
                    bookingHistories.Add(bookingHistory);
                }
            }
            return bookingHistories;
        }
    }
}
