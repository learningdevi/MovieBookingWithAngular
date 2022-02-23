using System;
using System.Collections.Generic;

namespace Microsoft.Core.Repository.Models
{
    public partial class Role
    {
        public Role()
        {
            RoleMappers = new HashSet<RoleMapper>();
        }

        public int Id { get; set; }
        public string Role1 { get; set; } = null!;

        public virtual ICollection<RoleMapper> RoleMappers { get; set; }
    }
}
