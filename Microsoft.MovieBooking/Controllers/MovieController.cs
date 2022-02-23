/*
 * Copyright - Microsoft
 */
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Core.BookingService;
using Microsoft.MovieBooking.Models;

namespace Microsoft.MovieBooking.Controllers
{
    /// <summary>
    /// This controller helps to process request.
    /// </summary>
    public class MovieController : Controller
    {
        private readonly ILogger<MovieController> logger;
        private readonly IMapper mapper;
        private readonly IMovieService movieService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieController"/> class.
        /// </summary>
        /// <param name="movieService">Represents <see cref="MovieService"/>.</param>
        public MovieController(ILogger<MovieController> logger, IMapper mapper, IMovieService movieService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.movieService = movieService;
        }

        /// <summary>
        /// Movies action method to list all the movies.
        /// </summary>
        /// <returns>Retuns <see cref="ActionResult"/>.</returns>
        public IActionResult Movies()
        {
            MovieViewModel movieViewModel = new()
            {
                Movies = this.movieService.GetMovies().ToList(),
                MovieLanguage = this.movieService.GetMovieLanguages().ToList(),
                MovieType = this.movieService.GetMovieType().ToList(),
                Genre = this.movieService.GetMovieGenres().ToList()
            };
            return View(movieViewModel);
        }

        /// <summary>
        /// This action methods filters movies by language.
        /// </summary>
        /// <param name="language">Represents language.</param>
        /// <returns>Returns <see cref="ActionResult"/>.</returns>
        public IActionResult MoviesByLanguage(string language)
        {
            MovieViewModel movieViewModel = new()
            {
                Movies = this.movieService.GetMovieByLanguage(language).ToList(),
                MovieLanguage = this.movieService.GetMovieLanguages().ToList(),
                MovieType = this.movieService.GetMovieType().ToList(),
                Genre = this.movieService.GetMovieGenres().ToList()
            };
            return View("Movies",movieViewModel);
        }

        /// <summary>
        /// This action methods filters movies by genres.
        /// </summary>
        /// <param name="genres">Represents genres.</param>
        /// <returns>Returns <see cref="ActionResult"/>.</returns>
        public IActionResult MoviesByGenres(string genres)
        {
            MovieViewModel movieViewModel = new()
            {
                Movies = this.movieService.GetMovieByGenres(genres).ToList(),
                MovieLanguage = this.movieService.GetMovieLanguages().ToList(),
                MovieType = this.movieService.GetMovieType().ToList(),
                Genre = this.movieService.GetMovieGenres().ToList()
            };
            return View("Movies", movieViewModel);
        }

        /// <summary>
        /// This action method filters movie by format.
        /// </summary>
        /// <param name="type">Represents movie format.</param>
        /// <returns>Returns <see cref="ActionResult"/>.</returns>
        public IActionResult MoviesByFormat(string type)
        {
            MovieViewModel movieViewModel = new()
            {
                Movies = this.movieService.GetMovieByFormat(type).ToList(),
                MovieLanguage = this.movieService.GetMovieLanguages().ToList(),
                MovieType = this.movieService.GetMovieType().ToList(),
                Genre = this.movieService.GetMovieGenres().ToList()
            };
            return View("Movies", movieViewModel);
        }
    }
}
