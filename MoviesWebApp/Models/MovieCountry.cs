using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWebApp.Models
{
    public class MovieCountry
    {
        public int? CountryId { get; set; }
        public Guid? MovieId { get; set; }

        [ForeignKey("MovieId")]
        public Movie? Movie { get; set; }
        [ForeignKey("CountryId")]
        public Country? Country { get; set; }
    }
}
