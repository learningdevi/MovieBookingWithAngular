using System;
using System.Collections.Generic;

namespace Microsoft.Core.Repository.Models
{
    public partial class ShowTiming
    {
        public ShowTiming()
        {
            SeatMappers = new HashSet<SeatMapper>();
            Shows = new HashSet<Show>();
        }

        public int Id { get; set; }
        public TimeSpan Timings { get; set; }

        public virtual ICollection<SeatMapper> SeatMappers { get; set; }
        public virtual ICollection<Show> Shows { get; set; }
    }
}
