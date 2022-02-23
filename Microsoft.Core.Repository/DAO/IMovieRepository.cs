/*
 * Copyright - Microsoft
 */
using Microsoft.Core.Repository.Models;

namespace Microsoft.Core.Repository.DAO
{
    /// <summary>
    /// This interface provides API to read and write movie details to DB.
    /// </summary>
    public interface IMovieRepository
    {
        /// <summary>
        /// Get all the movie details.
        /// </summary>
        /// <returns>Returns list of movie object.</returns>
        public IEnumerable<Movie> GetMovies();

        /// <summary>
        /// Get movie details by id.
        /// </summary>
        /// <param name="id">Represents movie id.</param>
        /// <returns>Returns movie object.</returns>
        public Movie GetMovie(int id);

        /// <summary>
        /// Save movie details into DB.
        /// </summary>
        /// <param name="movie">Represents <see cref="Movie"/> object.</param>
        /// <returns>Returns movie object.</returns>
        public Movie SaveMovie(Movie movie);

        /// <summary>
        /// Get all the languages.
        /// </summary>
        /// <returns>Returns language collection.</returns>
        public IEnumerable<MovieLanguage> GetMovieLanguages();

        /// <summary>
        /// Get language by Id.
        /// </summary>
        /// <param name="languageId">Represents Langauge id.</param>
        /// <returns>Returns language object. </returns>
        public MovieLanguage GetMovieLanguages(int languageId);

        /// <summary>
        /// Get movie genres.
        /// </summary>
        /// <returns>Returns genres collection.</returns>
        public IEnumerable<MovieGenre> GetMovieGenres();

        /// <summary>
        /// Get movie genre by Id.
        /// </summary>
        /// <param name="genreId">Represents genre id.</param>
        /// <returns>Returns movie genres object.</returns>
        public MovieGenre GetMovieGenre(int genreId);

        /// <summary>
        /// Get movie formats.
        /// </summary>
        /// <returns>Returns movie format colleciton.</returns>
        public IEnumerable<MovieType> GetMovieTypes();

        /// <summary>
        /// Get movie formats by Id.
        /// </summary>
        /// <param name="movieId">Represents movie id.</param>
        /// <returns>Returns movie format object.</returns>
        public MovieType GetMovieType(int movieId);
    }
}
