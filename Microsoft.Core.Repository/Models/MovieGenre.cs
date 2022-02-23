using System;
using System.Collections.Generic;

namespace Microsoft.Core.Repository.Models
{
    public partial class MovieGenre
    {
        public MovieGenre()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Genres { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
