namespace Microsoft.MovieBooking.Models
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public int MobileNo { get; set; }
        public string EmailId { get; set; } 
        public string? Address { get; set; }
    }
}
