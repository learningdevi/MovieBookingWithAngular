/*
 * Copyright - Microsoft
 */
using System;
using System.Collections.Generic;

namespace Microsoft.Core.Repository.Models
{
    /// <summary>
    /// This entity represents booking history.
    /// </summary>
    public partial class BookingHistory
    {
        /// <summary>
        /// Get's or Set's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets customer id.
        /// </summary>
        public int? CustomerId { get; set; }

        /// <summary>
        /// Gets or Sets booking date.
        /// </summary>
        public DateTime BookingDate { get; set; }

        /// <summary>
        /// Gets or Sets movie show date.
        /// </summary>
        public DateTime MovieShowDate { get; set; }

        /// <summary>
        /// Gets or Sets seat mapper id.
        /// </summary>
        public int? SeatMapperId { get; set; }

        /// <summary>
        /// Gets or Sets shows mapper id.
        /// </summary>
        public int? ShowsMapperId { get; set; }

        /// <summary>
        /// Gets or Sets booking status.
        /// </summary>
        public int BookingStatus { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual SeatMapper? SeatMapper { get; set; }
        public virtual ShowsMapper? ShowsMapper { get; set; }
    }
}
