/*
 * Copyright - Microsoft
 */
using Microsoft.Core.Repository.DAO;
using Microsoft.Core.Repository.Models;
using Microsoft.Extensions.Logging;

namespace Microsoft.Core.BookingService
{
    /// <summary>
    /// This interface provides capabilities to get Theatre and show details.
    /// It provides capablity to book shows.
    /// </summary>
    public class TheatreShowService : ITheatreShowService
    {
        private readonly ILogger<TheatreShowService> logger;
        private readonly ITheatreShowRepository theatreShowRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TheatreShowService"/> class.
        /// </summary>
        /// <param name="theatreShowRepository">Represetns <see cref="TheatreShowRepository"/> object.</param>
        public TheatreShowService(ITheatreShowRepository theatreShowRepository,
            ILogger<TheatreShowService> logger)
        {
            this.theatreShowRepository = theatreShowRepository;
            this.logger = logger;
        }

        /// <summary>
        /// This method helps to book the movie show.
        /// </summary>
        /// <param name="bookingHistorys">Represents <see cref="BookingHistory"/>.</param>
        /// <returns>Return <see cref="BookingHistory"/>.</returns>
        public BookingHistory BookShow(List<BookingHistory> bookingHistorys)
        {
            BookingHistory result = null;
            try
            {
                foreach (BookingHistory history in bookingHistorys)
                {
                    result = this.theatreShowRepository.BookShow(history);
                    int seatMapperId = history.SeatMapperId ?? 0;
                    SeatMapper mapper = this.theatreShowRepository.GetSeatMapper(seatMapperId);
                    mapper.Availability = 0;
                    this.theatreShowRepository.BlockSeats(mapper);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while processing booking history details : {ex.Message}");
            }

            return result;
        }

        /// <summary>
        /// This method cancel the booking.
        /// </summary>
        /// <param name="bookingHistory">Represents <see cref="BookingHistory"/>.</param>
        /// <returns><Returns <see cref="BookingHistory"/>object.</returns>
        public BookingHistory CancelShow(BookingHistory bookingHistory)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method retrieves seat mapper details.
        /// </summary>
        /// <param name="theatreId">Represents theatre id.</param>
        /// <param name="dateTime">Represents show date.</param>
        /// <param name="showTimingsId">Represents show timings.</param>
        /// <returns>Returns <see cref="SeatMapper"/>collection.</returns>
        public List<SeatMapper> GetSeatMapper(int theatreId, DateTime dateTime, int showTimingsId)
        {
            try
            {
                return this.theatreShowRepository.GetSeatMapper(theatreId, dateTime, showTimingsId).ToList();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading seat mapper : {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// This method retrieves shows mapper details.
        /// </summary>
        /// <param name="movieId">Represents movie id.</param>
        /// <param name="dateTime">Represents movie show date.</param>
        /// <returns>Returns <see cref="ShowMapper"/>collection.</returns>
        public List<ShowsMapper> GetShowsByMovie(int movieId, DateTime dateTime)
        {
            try
            {
                return this.theatreShowRepository.GetShowsByMovie(movieId, dateTime).ToList();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading movie show details : {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// This method retrieves theatre details.
        /// </summary>
        /// <param name="id">Represents <see cref="int"/>TheatreId.</param>
        /// <returns>Returns <see cref="Theatre"/>object.</returns>
        public Theatre GetTheatre(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method retrieves theatre details.
        /// </summary>
        /// <returns>Returns <see cref="Theatre"/>collection.</returns>
        public List<Theatre> GetTheatres()
        {
            throw new NotImplementedException();
        }
    }
}
