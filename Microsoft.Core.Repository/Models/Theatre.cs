using System;
using System.Collections.Generic;

namespace Microsoft.Core.Repository.Models
{
    public partial class Theatre
    {
        public Theatre()
        {
            SeatMappers = new HashSet<SeatMapper>();
            Shows = new HashSet<Show>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }

        public virtual ICollection<SeatMapper> SeatMappers { get; set; }
        public virtual ICollection<Show> Shows { get; set; }
    }
}
