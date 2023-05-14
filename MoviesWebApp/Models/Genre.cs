using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWebApp.Models
{
    public class Genre
    {
        [Key]
        public int GenreID { get; set; }
        [Required]
        [Column(TypeName = ("nvarchar(50)"))]
        public string GenreName { get; set; }

        public ICollection<MovieGenre>? MovieGenres { get; set; }
    }
}
