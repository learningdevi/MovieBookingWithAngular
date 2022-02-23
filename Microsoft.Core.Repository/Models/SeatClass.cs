using System;
using System.Collections.Generic;

namespace Microsoft.Core.Repository.Models
{
    public partial class SeatClass
    {
        public SeatClass()
        {
            SeatMappers = new HashSet<SeatMapper>();
        }

        public int Id { get; set; }
        public string ClassType { get; set; } = null!;

        public virtual ICollection<SeatMapper> SeatMappers { get; set; }
    }
}
