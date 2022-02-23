using Microsoft.Core.Repository.Models;

namespace Microsoft.MovieBooking.Models
{
    public class ShowsViewModel
    {
        public List<ShowsMapper> ShowsMappers { get; set; }
        public List<SeatMapper> SeatMappers { get; set;}
    }
}
