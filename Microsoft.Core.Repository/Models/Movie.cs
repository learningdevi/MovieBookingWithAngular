using System;
using System.Collections.Generic;

namespace Microsoft.Core.Repository.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Shows = new HashSet<Show>();
        }

        public int Id { get; set; }
        public string? MovieName { get; set; }
        public string? Description { get; set; }
        public int? LangaugeId { get; set; }
        public int? TypeId { get; set; }
        public int? GenresId { get; set; }

        public virtual MovieGenre? Genres { get; set; }
        public virtual MovieLanguage? Langauge { get; set; }
        public virtual MovieType? Type { get; set; }
        public virtual ICollection<Show> Shows { get; set; }
    }
}
