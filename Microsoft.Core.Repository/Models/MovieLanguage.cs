using System;
using System.Collections.Generic;

namespace Microsoft.Core.Repository.Models
{
    public partial class MovieLanguage
    {
        public MovieLanguage()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Language { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
