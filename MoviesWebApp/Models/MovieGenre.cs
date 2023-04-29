using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWebApp.Models
{
    public class MovieGenre
    {
        public int? GenreId { get; set; }
        public Guid? MovieId { get; set; }

        [ForeignKey("MovieId")]
        public Movie? Movie { get; set; }
        [ForeignKey("GenreId")]
        public Genre? Genre { get; set; }
    }
}
