/*
 * Copyright - Microsoft
 */
using Microsoft.Core.Repository.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Logging;

namespace Microsoft.Core.Repository.DAO
{
    /// <summary>
    /// This class provides capablity to display movie show details and book shows.
    /// </summary>
    public class TheatreShowRepository : ITheatreShowRepository
    {
        private readonly ILogger<TheatreShowRepository> logger;
        private readonly IRepository<Theatre> theatreRepository;
        private readonly IRepository<ShowsMapper> showMapperRepository;
        private readonly IRepository<SeatMapper> seatMapperRepository;
        private readonly IRepository<BookingHistory> bookingHistoryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TheatreShowRepository"/> class.
        /// </summary>
        /// <param name="theatreRepository">Represents <see cref="Theatre"/>Repository.</param>
        /// <param name="showsMapperRepository">Represents <see cref="ShowsMapper"/>Repository.</param>
        /// <param name="seatMapperRepository">Represents <see cref="SeatMapper"/>Repository.</param>
        /// <param name="bookingHistoryRepository">Represents <see cref="BookingHistory"/>Repository.</param>
        public TheatreShowRepository(
            IRepository<Theatre> theatreRepository,
            IRepository<ShowsMapper> showsMapperRepository,
            IRepository<SeatMapper> seatMapperRepository,
            IRepository<BookingHistory> bookingHistoryRepository,
            ILogger<TheatreShowRepository> logger)
        {
            this.theatreRepository = theatreRepository;
            this.showMapperRepository = showsMapperRepository;
            this.seatMapperRepository = seatMapperRepository;
            this.bookingHistoryRepository = bookingHistoryRepository;
            this.logger = logger;
        }

        /// <summary>
        /// This method retrieve the theatre details.
        /// </summary>
        /// <param name="id">Represents <see cref="int"/> TheatreId.</param>
        /// <returns>Returns <see cref="Theatre"/>object.</returns>
        public Theatre GetTheatre(int id)
        {
            try
            {
                return this.theatreRepository.Get(id);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading theatre details from DB : {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// This methods retrieve all the theatre details.
        /// </summary>
        /// <returns>Represents <see cref="Theatre"/> collection.</returns>
        public IEnumerable<Theatre> GetTheatres()
        {
            try
            {
                return this.theatreRepository.GetAll(null);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading theatres details from DB : {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// This method retrieve the Seat Mapping details.
        /// </summary>
        /// <param name="theatreId">Represents theatre id.</param>
        /// <param name="dateTime">Represents movie show date.</param>
        /// <param name="showTimingsId">Represents show timings.</param>
        /// <returns>Returns <see cref="SeatMapper"/>collection.</returns>
        public IEnumerable<SeatMapper> GetSeatMapper(int theatreId, DateTime dateTime, int showTimingsId)
        {
            try
            {
                string[] child = { "SeatClass", "ShowTimings", "Theater" };
                return this.seatMapperRepository.GetAll(child).Where(
                    x => x.TheaterId == theatreId && x.Date == dateTime && x.ShowTimingsId == showTimingsId);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading seat mapper from DB : {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// This method retrieves the seat mappping details.
        /// </summary>
        /// <param name="seatMapperId">Represents seat mapper id.</param>
        /// <returns>Returns <see cref="SeatMapper"/>object.</returns>

        public SeatMapper GetSeatMapper(int seatMapperId)
        {
            try
            {
                string[] child = { "SeatClass", "ShowTimings", "Theater" };
                return this.seatMapperRepository.GetAll(child).Where(
                    x => x.Id == seatMapperId).First();
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading seat mapper from DB : {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// This method retrieve the seat mapping details.
        /// </summary>
        /// <param name="movieId">Represents movie id.</param>
        /// <param name="dateTime">Represents movie show date.</param>
        /// <returns>Represents <see cref="ShowsMapper"/>colleciton.</returns>
        public IEnumerable<ShowsMapper> GetShowsByMovie(int movieId, DateTime dateTime)
        {
            try
            {
                string[] child = { "Shows", "Shows.Movie", "Shows.ShowTimings", "Shows.Theatre" };
                return this.showMapperRepository.GetAll(child).Where(x => x.Shows?.MovieId == movieId && x.MovieShowDate == dateTime);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while reading show details from DB : {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// This method book the show and save in db.
        /// </summary>
        /// <param name="bookingHistory">Represents <see cref="BookingHistory"/>object.</param>
        /// <returns>Returns <see cref="BookingHistory"/>object.</returns>
        public BookingHistory BookShow(BookingHistory bookingHistory)
        {
            try
            {
                BookingHistory record = this.bookingHistoryRepository.Save(bookingHistory);
                return record;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while booking show into DB : {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// This method block the seats for booking.
        /// </summary>
        /// <param name="seatMapper">Represents <see cref="SeatMapper"/>object.</param>
        /// <returns>Returns <see cref="SeatMapper"/> object.</returns>
        public SeatMapper BlockSeats(SeatMapper seatMapper)
        {
            try
            {
                return this.seatMapperRepository.Save(seatMapper);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while saving booked seats details into DB : {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// This method cancel the booking.
        /// </summary>
        /// <param name="bookingHistory">Represents <see cref="BookingHistory"/>.</param>
        /// <returns>Returns <see cref="BookingHistory"/>.</returns>
        public BookingHistory CancelShow(BookingHistory bookingHistory)
        {
            try
            {
                return this.bookingHistoryRepository.Save(bookingHistory);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured while saving cancelling shows details into DB  : {ex.Message}");
                return null;
            }

        }
    }
}
