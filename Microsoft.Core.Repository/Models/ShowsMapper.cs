using System;
using System.Collections.Generic;

namespace Microsoft.Core.Repository.Models
{
    public partial class ShowsMapper
    {
        public ShowsMapper()
        {
            BookingHistories = new HashSet<BookingHistory>();
        }

        public int Id { get; set; }
        public DateTime MovieShowDate { get; set; }
        public int? ShowsId { get; set; }

        public virtual Show? Shows { get; set; }
        public virtual ICollection<BookingHistory> BookingHistories { get; set; }
    }
}
