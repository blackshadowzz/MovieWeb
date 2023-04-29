using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWebApp.Models
{
    public class MovieStudio
    {
        public int? StudioId { get; set; }
        public Guid? MovieId { get; set; }

        [ForeignKey("MovieId")]
        public Movie? Movie { get; set; }
        [ForeignKey("StudioId")]
        public Studio? Studio { get; set; }
    }
}
