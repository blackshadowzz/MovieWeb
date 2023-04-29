using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWebApp.Models
{
    public class Studio
    {
        [Key]
        public int StudioId { get; set; }
        [Column(TypeName = ("nvarchar(50)"))]
        public string? Name { get; set; }
        [Column(TypeName = ("nvarchar(50)"))]
        public string? Location { get; set; }
        [Column(TypeName = ("decimal(18,2)"))]
        public decimal? Revenue { get; set; }

        // Navigation properties
        public ICollection<MovieStudio>? MovieStudios { get; set; }
       
    }
}
