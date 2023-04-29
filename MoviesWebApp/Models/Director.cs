using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWebApp.Models
{
    public class Director 
    {
        [Key]
        public Guid DirectorID { get; set; }
        [Required]
        [Column(TypeName =("nvarchar(50)"))]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = ("nvarchar(50)"))]
        public string LastName { get; set; }
        [ForeignKey("Gender")]
        public int? GenderID { get ; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        [Column(TypeName = ("nvarchar(20)"))]
        public string? Phone { get; set; }
        [Column(TypeName = ("nvarchar(100)"))]
        public string? Email { get; set; }
        [Column(TypeName = ("nvarchar(50)"))]
        public string? Role { get; set; }
        [Column(TypeName = ("nvarchar(200)"))]
        public string? Address { get; set; } 
      

        public Genders? Gender { get; set; }
        public ICollection<MovieDirector>? MovieDirectors { get; set; }
    }
    public enum Genders
    {
        Male,
        Female,
        Others
    }

}
