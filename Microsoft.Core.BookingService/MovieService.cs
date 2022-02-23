/*
 * Copyright - Microsoft
 */
using Microsoft.Core.Repository.DAO;
using Microsoft.Core.Repository.Models;
using Microsoft.Extensions.Logging;

namespace Microsoft.Core.BookingService
{
    /// <summary>
    /// This class provides API to handle movie services
    /// </summary>
    public class MovieService : IMovieService
    {
        private readonly ILogger<MovieService> logger;
        private readonly IMovieRepository movieRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieService"/> class.
        /// </summary>
        /// <param name="repository">Represents <see cref="MovieRepository"/>.</param>
        public MovieService(IMovieRepository repository, ILogger<MovieService> logger)
        {
            this.movieRepository = repository;
            this.logger = logger;
        }

        /// <summary>
        /// Get movies by format.
        /// </summary>
        /// <param name="format">Represents format.</param>
        /// <returns>Returns format collection.</returns>
        public IEnumerable<Movie> GetMovieByFormat(string format)
        {
            try
            {
                return this.movieRepository.GetMovies().Where(x => x.Type?.Type == format);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading movies details : {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// Get movies by genres.
        /// </summary>
        /// <param name="genres">Represents genre.</param>
        /// <returns>Returns movie collection.</returns>
        public IEnumerable<Movie> GetMovieByGenres(string genres)
        {
            try
            {
                return this.movieRepository.GetMovies().Where(x => x.Genres?.Genres == genres);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading movies details : {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// Get movie details by id.
        /// </summary>
        /// <param name="id">Represents id.</param>
        /// <returns>Returns movie object.</returns>
        public Movie GetMovieById(int id)
        {
            try
            {
                return this.movieRepository.GetMovie(id);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading movies details : {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// Get movies by language.
        /// </summary>
        /// <param name="language">Represents language.</param>
        /// <returns>Returns language.</returns>
        public IEnumerable<Movie> GetMovieByLanguage(string language)
        {
            try
            {
                return this.movieRepository.GetMovies().Where(x => x.Langauge?.Language == language);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading movies details : {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// Get movie genres.
        /// </summary>
        /// <returns>Returns <see cref="MovieGenre"/> colleciton.</returns>
        public IEnumerable<MovieGenre> GetMovieGenres()
        {
            try
            {
                return this.movieRepository.GetMovieGenres();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading movies details : {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// Get movie languages.
        /// </summary>
        /// <returns>Returns <see cref="MovieLanguage"/>.</returns>
        public IEnumerable<MovieLanguage> GetMovieLanguages()
        {
            try
            {
                return this.movieRepository.GetMovieLanguages();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading movies details : {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// Get movies.
        /// </summary>
        /// <returns>Returns movies collection.</returns>
        public IEnumerable<Movie> GetMovies()
        {
            try
            {
                return this.movieRepository.GetMovies();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading movies details : {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// Get movie type.
        /// </summary>
        /// <returns>Return <see cref="MovieType"/> collection.</returns>
        public IEnumerable<MovieType> GetMovieType()
        {
            try
            {
                return this.movieRepository.GetMovieTypes();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading movies details : {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// Save movies.
        /// </summary>
        /// <param name="movie">Represents <see cref="Movie"/> object.</param>
        /// <returns>Returns movie object.</returns>
        public Movie SaveMovie(Movie movie)
        {
            try
            {
                return this.movieRepository.SaveMovie(movie);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while saving movies details : {ex.Message}");
                return null;
            }

        }
    }
}
