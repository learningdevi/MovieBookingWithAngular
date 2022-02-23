/*
 * Copyright - Microsoft
 */
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Core.BookingService;
using Microsoft.Core.Repository.Models;
using Microsoft.MovieBooking.Models;
using System.Diagnostics;

namespace Microsoft.MovieBooking.Controllers
{
    /// <summary>
    /// This controller helps to process request.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IMapper mapper;
        private readonly ICustomerService customerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">Represents logger.</param>
        /// <param name="mapper">Represents mapper.</param>
        /// <param name="customerService">Represents customer service.</param>
        public HomeController(ILogger<HomeController> logger, IMapper mapper, ICustomerService customerService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.customerService = customerService;
        }

        /// <summary>
        /// Index action method.
        /// </summary>
        /// <returns>Returns <see cref="ActionResult"/>.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Privacy action method.
        /// </summary>
        /// <returns>Returns <see cref="ActionResult"/>.</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Register action method.
        /// </summary>
        /// <returns>Returns <see cref="ActionResult"/>.</returns>
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Register action method.
        /// </summary>
        /// <returns>Returns <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            ViewBag.RegistrationStatus = true;
            Customer customer = mapper.Map<Customer>(model);
            customerService.RegisterCustomer(customer);
            return RedirectToAction("Login");
        }

        /// <summary>
        /// Login action method.
        /// </summary>
        /// <returns>Returns <see cref="ActionResult"/>.</returns>
        public IActionResult Login()
        {

            return View();
        }

        /// <summary>
        /// Login action method.
        /// </summary>
        /// <returns>Returns <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public IActionResult Login(string Id, int OTP)
        {
            if (OTP == 1234)
                return RedirectToAction("Movies", "Movie");
            return View("Error");
        }

        /// <summary>
        /// Error action method.
        /// </summary>
        /// <returns>Returns <see cref="ActionResult"/>.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}