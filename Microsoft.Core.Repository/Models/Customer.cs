using System;
using System.Collections.Generic;

namespace Microsoft.Core.Repository.Models
{
    public partial class Customer
    {
        public Customer()
        {
            BookingHistories = new HashSet<BookingHistory>();
            RoleMappers = new HashSet<RoleMapper>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int MobileNo { get; set; }
        public string EmailId { get; set; } = null!;
        public string? Address { get; set; }

        public virtual ICollection<BookingHistory> BookingHistories { get; set; }
        public virtual ICollection<RoleMapper> RoleMappers { get; set; }
    }
}
