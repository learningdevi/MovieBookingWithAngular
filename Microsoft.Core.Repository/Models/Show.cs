using System;
using System.Collections.Generic;

namespace Microsoft.Core.Repository.Models
{
    public partial class Show
    {
        public Show()
        {
            ShowsMappers = new HashSet<ShowsMapper>();
        }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? ShowTimingsId { get; set; }
        public int? TheatreId { get; set; }
        public int? MovieId { get; set; }

        public virtual Movie? Movie { get; set; }
        public virtual ShowTiming? ShowTimings { get; set; }
        public virtual Theatre? Theatre { get; set; }
        public virtual ICollection<ShowsMapper> ShowsMappers { get; set; }
    }
}
