/*
 * Copyright - Microsoft
 */
using Microsoft.Core.Repository.Models;

namespace Microsoft.MovieBooking.Models
{
    public class MovieViewModel
    {
        /// <summary>
        /// This property represents movie object
        /// </summary>
        public List<Movie> Movies { get; set; }
        /// <summary>
        /// This property represents movie type
        /// </summary>
        public List<MovieType> MovieType { get; set; }
        /// <summary>
        /// This property represents movie language
        /// </summary>
        public List<MovieLanguage> MovieLanguage { get; set; }
        /// <summary>
        /// This property represents movie genre
        /// </summary>
        public List<MovieGenre> Genre { get; set; }
    }
}
