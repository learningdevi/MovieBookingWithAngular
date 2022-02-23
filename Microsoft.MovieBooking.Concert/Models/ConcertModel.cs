namespace Microsoft.MovieBooking.Concert.Models
{
    /// <summary>
    /// This represents concert object
    /// </summary>
    public class ConcertModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ShowDate { get; set; }
        public string ShowTime { get; set; }
        //public string ImageUrl { get; set; }
    }
}
