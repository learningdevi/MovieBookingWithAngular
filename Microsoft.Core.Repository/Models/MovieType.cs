using System;
using System.Collections.Generic;

namespace Microsoft.Core.Repository.Models
{
    public partial class MovieType
    {
        public MovieType()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Type { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
