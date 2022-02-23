/*
 * Copyright - Microsoft
 */
using Microsoft.Core.Repository.Models;

namespace Microsoft.Core.BookingService
{
    /// <summary>
    /// This interface provides capabilities to get Theatre and show details.
    /// It provides capablity to book shows.
    /// </summary>
    public interface ITheatreShowService
    {
        /// <summary>
        /// This method retrieves theatre details.
        /// </summary>
        /// <returns>Returns <see cref="Theatre"/>collection.</returns>
        public List<Theatre> GetTheatres();

        /// <summary>
        /// This method retrieves theatre details.
        /// </summary>
        /// <param name="id">Represents <see cref="int"/>TheatreId.</param>
        /// <returns>Returns <see cref="Theatre"/>object.</returns>
        public Theatre GetTheatre(int id);

        /// <summary>
        /// This method retrieves seat mapper details.
        /// </summary>
        /// <param name="theatreId">Represents theatre id.</param>
        /// <param name="dateTime">Represents show date.</param>
        /// <param name="showTimingsId">Represents show timings.</param>
        /// <returns>Returns <see cref="SeatMapper"/>collection.</returns>
        public List<SeatMapper> GetSeatMapper(int theatreId, DateTime dateTime, int showTimingsId);

        /// <summary>
        /// This method retrieves shows mapper details.
        /// </summary>
        /// <param name="movieId">Represents movie id.</param>
        /// <param name="dateTime">Represents movie show date.</param>
        /// <returns>Returns <see cref="ShowMapper"/>collection.</returns>
        public List<ShowsMapper> GetShowsByMovie(int movieId, DateTime dateTime);

        /// <summary>
        /// This method cancel the booking.
        /// </summary>
        /// <param name="bookingHistory">Represents <see cref="BookingHistory"/>.</param>
        /// <returns><Returns <see cref="BookingHistory"/>object.</returns>
        public BookingHistory CancelShow(BookingHistory bookingHistory);

        /// <summary>
        /// This method helps to book the movie show.
        /// </summary>
        /// <param name="bookingHistorys">Represents <see cref="BookingHistory"/>.</param>
        /// <returns>Return <see cref="BookingHistory"/>.</returns>
        public BookingHistory BookShow(List<BookingHistory> bookingHistorys);
    }
}
