/*
 * Copyright - Microsoft
 */
using Microsoft.Core.Repository.Models;

namespace Microsoft.Core.Repository.DAO
{
    /// <summary>
    /// This interface provides capablity to display movie show details and book shows.
    /// </summary>
    public interface ITheatreShowRepository
    {
        /// <summary>
        /// This methods retrieve all the theatre details.
        /// </summary>
        /// <returns>Represents <see cref="Theatre"/> collection.</returns>
        public IEnumerable<Theatre> GetTheatres();

        /// <summary>
        /// This method retrieve the theatre details
        /// </summary>
        /// <param name="id">Represents <see cref="int"/> TheatreId.</param>
        /// <returns>Returns <see cref="Theatre"/>object.</returns>
        public Theatre GetTheatre(int id);

        /// <summary>
        /// This method retrieve the Seat Mapping details.
        /// </summary>
        /// <param name="theatreId">Represents theatre id.</param>
        /// <param name="dateTime">Represents movie show date.</param>
        /// <param name="showTimingsId">Represents show timings.</param>
        /// <returns>Returns <see cref="SeatMapper"/>collection.</returns>
        public IEnumerable<SeatMapper> GetSeatMapper(int theatreId, DateTime dateTime, int showTimingsId);

        /// <summary>
        /// This method retrieve the seat mapping details.
        /// </summary>
        /// <param name="movieId">Represents movie id.</param>
        /// <param name="dateTime">Represents movie show date.</param>
        /// <returns>Represents <see cref="ShowsMapper"/>colleciton.</returns>
        public IEnumerable<ShowsMapper> GetShowsByMovie(int movieId, DateTime dateTime);

        /// <summary>
        /// This method book the show and save in db.
        /// </summary>
        /// <param name="bookingHistory">Represents <see cref="BookingHistory"/>object.</param>
        /// <returns>Returns <see cref="BookingHistory"/>object.</returns>
        public BookingHistory BookShow(BookingHistory bookingHistory);

        /// <summary>
        /// This method cancel the booking.
        /// </summary>
        /// <param name="bookingHistory">Represents <see cref="BookingHistory"/>.</param>
        /// <returns>Returns <see cref="BookingHistory"/>.</returns>
        public BookingHistory CancelShow(BookingHistory bookingHistory);

        /// <summary>
        /// This method block the seats for booking.
        /// </summary>
        /// <param name="seatMapper">Represents <see cref="SeatMapper"/>object.</param>
        /// <returns>Returns <see cref="SeatMapper"/> object.</returns>
        public SeatMapper BlockSeats(SeatMapper seatMapper);

        /// <summary>
        /// This method retrieves the seat mappping details.
        /// </summary>
        /// <param name="seatMapperId">Represents seat mapper id.</param>
        /// <returns>Returns <see cref="SeatMapper"/>object.</returns>
        public SeatMapper GetSeatMapper(int seatMapperId);
    }
}
