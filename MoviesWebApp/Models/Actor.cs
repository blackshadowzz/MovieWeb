using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoviesWebApp.Models
{
    public class Actor
    {
        [Key]
        public Guid ActorID { get; set; }
        [Required]
        [Column(TypeName = ("nvarchar(50)"))]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = ("nvarchar(50)"))]
        public string LastName { get; set; }
        public Genders? Gender { get; set; }
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
        [Column(TypeName = ("nvarchar(200)"))]
        public string? Description { get; set; }

      
        public ICollection<MovieActor>? MovieActors { get; set; }
    }

}
