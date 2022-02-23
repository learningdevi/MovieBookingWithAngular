/*
 * Copyright - Microsoft
 */
using Microsoft.Core.Repository.Models;

namespace Microsoft.Core.BookingService
{
    /// <summary>
    /// This interface provides API to handle movie services.
    /// </summary>
    public interface IMovieService
    {
        /// <summary>
        /// Get movies.
        /// </summary>
        /// <returns>Returns movies collection.</returns>
        public IEnumerable<Movie> GetMovies();

        /// <summary>
        /// Get movie details by id.
        /// </summary>
        /// <param name="id">Represents id.</param>
        /// <returns>Returns movie object.</returns>
        public Movie GetMovieById(int id);

        /// <summary>
        /// Get movies by genres.
        /// </summary>
        /// <param name="genres">Represents genre.</param>
        /// <returns>Returns movie collection.</returns>
        public IEnumerable<Movie> GetMovieByGenres(string genres);

        /// <summary>
        /// Get movies by format.
        /// </summary>
        /// <param name="format">Represents format.</param>
        /// <returns>Returns format collection.</returns>
        public IEnumerable<Movie> GetMovieByFormat(string format);

        /// <summary>
        /// Get movies by language.
        /// </summary>
        /// <param name="language">Represents language.</param>
        /// <returns>Returns language.</returns>
        public IEnumerable<Movie> GetMovieByLanguage(string language);

        /// <summary>
        /// Save movies.
        /// </summary>
        /// <param name="movie">Represents <see cref="Movie"/> object.</param>
        /// <returns>Returns movie object.</returns>
        public Movie SaveMovie(Movie movie);

        /// <summary>
        /// Get movie genres.
        /// </summary>
        /// <returns>Returns <see cref="MovieGenre"/> colleciton.</returns>
        public IEnumerable<MovieGenre> GetMovieGenres();

        /// <summary>
        /// Get movie languages.
        /// </summary>
        /// <returns>Returns <see cref="MovieLanguage"/>.</returns>
        public IEnumerable<MovieLanguage> GetMovieLanguages();

        /// <summary>
        /// Get movie type.
        /// </summary>
        /// <returns>Return <see cref="MovieType"/> collection.</returns>
        public IEnumerable<MovieType> GetMovieType();
    }
}
