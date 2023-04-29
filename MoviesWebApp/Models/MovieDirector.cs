using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWebApp.Models
{
    public class MovieDirector
    {
        public Guid? DirectorId { get; set; }
        public Guid? MovieId { get; set; }

        [ForeignKey("MovieId")]
        public Movie? Movie { get; set; }
        [ForeignKey("DirectorId")]
        public Director? Director { get; set; }
    }
}
