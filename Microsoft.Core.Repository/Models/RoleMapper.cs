using System;
using System.Collections.Generic;

namespace Microsoft.Core.Repository.Models
{
    public partial class RoleMapper
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Role? Role { get; set; }
    }
}
