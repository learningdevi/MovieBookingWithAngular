/*
 * Copyright - Microsoft
 */
using Microsoft.Core.Repository.Models;
using Microsoft.Extensions.Logging;

namespace Microsoft.Core.Repository.DAO
{
    /// <summary>
    /// This class provides capablities to read and write movie details into repository
    /// </summary>
    public class MovieRepository : IMovieRepository
    {
        private readonly ILogger<MovieRepository> logger;

        private readonly IRepository<Movie> movieRepository;
        private readonly IRepository<MovieLanguage> movieLanguageRepository;
        private readonly IRepository<MovieGenre> movieGenreRepository;
        private readonly IRepository<MovieType> movieTypeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieRepository"/> class.
        /// </summary>
        /// <param name="movieRepository">Represents <see cref="Movie"/>repository.</param>
        /// <param name="movieGenreRepository">Represents <see cref="MovieGenre"/>repository.</param>
        /// <param name="movieLanguageRepository">Represents <see cref="MovieLanguage"/>repository.</param>
        /// <param name="movieTypeRepository">Represents <see cref="MovieType"/>repository.</param>
        public MovieRepository(
            IRepository<Movie> movieRepository,
            IRepository<MovieGenre> movieGenreRepository,
            IRepository<MovieLanguage> movieLanguageRepository,
            IRepository<MovieType> movieTypeRepository, ILogger<MovieRepository> logger)
        {
            this.movieRepository = movieRepository;
            this.movieLanguageRepository = movieLanguageRepository;
            this.movieTypeRepository = movieTypeRepository;
            this.movieGenreRepository = movieGenreRepository;
            this.logger = logger;
        }

        /// <summary>
        /// Get the movie details from DB.
        /// </summary>
        /// <param name="id">Represents movie id.</param>
        /// <returns>Returns movie object.</returns>
        public Movie GetMovie(int id)
        {
            try
            {
                return this.movieRepository.Get(id);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading movie details from DB : {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Get movie genre by Id.
        /// </summary>
        /// <param name="genreId">Represents genre id.</param>
        /// <returns>Returns movie genres object.</returns>
        public MovieGenre GetMovieGenre(int genreId)
        {
            try
            {
                return this.movieGenreRepository.Get(genreId);
            }
            catch(Exception ex)
            {
                logger.LogError($"Exception occured while reading movie genre details from DB : {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Get movie genres.
        /// </summary>
        /// <returns>Returns genres collection.</returns>
        public IEnumerable<MovieGenre> GetMovieGenres()
        {
            try
            {
                return this.movieGenreRepository.GetAll(null);
            }
            catch(Exception ex)
            {
                logger.LogError($"Exception occured while reading moive genres from DB : {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Get all the languages.
        /// </summary>
        /// <returns>Returns language collection.</returns>
        public IEnumerable<MovieLanguage> GetMovieLanguages()
        {
            try
            {
                return this.movieLanguageRepository.GetAll(null);
            }
            catch(Exception ex)
            {
                logger.LogError($"Exception occured while reading movie langauges from DB : {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Get language by Id.
        /// </summary>
        /// <param name="languageId">Represents Langauge id.</param>
        /// <returns>Returns language object. </returns>
        public MovieLanguage GetMovieLanguages(int languageId)
        {
            try
            {
                return this.movieLanguageRepository.Get(languageId);
            }
            catch(Exception ex)
            {
                logger.LogError($"Exception occured while reading movie languages from DB : {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Get all the movie details from DB.
        /// </summary>
        /// <returns>Returns collection of movies.</returns>
        public IEnumerable<Movie> GetMovies()
        {
            try
            {
                var children = new string[] { "Genres", "Langauge", "Type" };
                return this.movieRepository.GetAll(children);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading movies from DB : {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Get movie formats by Id.
        /// </summary>
        /// <param name="movieId">Represents movie id.</param>
        /// <returns>Returns movie format object.</returns>
        public MovieType GetMovieType(int movieId)
        {
            try
            {
                return this.movieTypeRepository.Get(movieId);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading movies type from DB : {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// Get movie formats.
        /// </summary>
        /// <returns>Returns movie format colleciton.</returns>
        public IEnumerable<MovieType> GetMovieTypes()
        {
            try
            {
                return this.movieTypeRepository.GetAll(null);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading movies types from DB : {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// Save the movie details to DB.
        /// </summary>
        /// <param name="movie">Represents <see cref="Movie"/>.</param>
        /// <returns>Returns movie object.</returns>
        public Movie SaveMovie(Movie movie)
        {
            try
            {
                return this.movieRepository.Save(movie);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while saving movies into DB : {ex.Message}");
                return movie;
            }
        }
    }
}
