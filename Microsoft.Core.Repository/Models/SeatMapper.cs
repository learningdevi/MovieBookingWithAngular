using System;
using System.Collections.Generic;

namespace Microsoft.Core.Repository.Models
{
    public partial class SeatMapper
    {
        public SeatMapper()
        {
            BookingHistories = new HashSet<BookingHistory>();
        }

        public int Id { get; set; }
        public int? TheaterId { get; set; }
        public DateTime Date { get; set; }
        public int SeatNo { get; set; }
        public int? SeatClassId { get; set; }
        public int Availability { get; set; }
        public int? ShowTimingsId { get; set; }

        public virtual SeatClass? SeatClass { get; set; }
        public virtual ShowTiming? ShowTimings { get; set; }
        public virtual Theatre? Theater { get; set; }
        public virtual ICollection<BookingHistory> BookingHistories { get; set; }
    }
}
