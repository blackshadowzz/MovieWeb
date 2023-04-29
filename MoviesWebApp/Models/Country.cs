using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWebApp.Models
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }
        [Column(TypeName =("nvarchar(50)"))]
        public string? CountryName { get; set; }

        public ICollection<MovieCountry>? MovieCountries { get; set; }
    }
}
