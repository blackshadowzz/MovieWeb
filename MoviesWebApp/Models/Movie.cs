using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace MoviesWebApp.Models
{
    public class Movie
    {
        [Key]
        public Guid MovieId { get; set; }
        [Required]
        [StringLength(150,MinimumLength =3,ErrorMessage ="Must be 3 charactors up!")]
        [Column(TypeName =("nvarchar(150)"))]
        public string Title { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ReleasedDate { get; set; }
        public MovieLanguage? Language { get; set; }
        public decimal Rating { get; set; }
        [Column(TypeName = ("decimal(18,2)"))]
        public decimal? Budget { get; set; }
        [Column(TypeName = ("varchar(30)"))]
        public string? Duration { get; set; }
        public int? AgeLimited { get; set; }
        [Column(TypeName = ("nvarchar(200)"))]
        public string? CoverImage { get; set; }
        [Column(TypeName = ("nvarchar(200)"))]
        public string? BackCoverImage { get; set; }
        [Column(TypeName = ("varchar(500)"))]
        public string? Description { get; set; }

        [NotMapped]
        public IFormFile? FrontImage { get; set; }
        [NotMapped]
        public IFormFile? BackImage { get; set; }

        public ICollection<MovieStudio>? MovieStudios { get; set; }
        public ICollection<MovieActor>? MovieActors { get; set; }
        public ICollection<MovieCountry>? MovieCountries { get; set; }
        public ICollection<MovieDirector>? MovieDirectors { get; set; }
        public ICollection<MovieGenre>? MovieGenres { get; set; }
    }
    public enum MovieLanguage
    {
        English,
        Khmer,
        Japanese,
        Chinese,
        Korean
    }
}
