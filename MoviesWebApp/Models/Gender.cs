using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWebApp.Models
{
    public class Gender
    {
        [Key]
        [DisplayName("ID")]
        public int GenderID { get; set; }
        [Column(TypeName = ("nvarchar(15)")), DisplayName("Gender")]
        [Required]
        [StringLength(15,ErrorMessage ="Cannot input bigger than 15 characters!")]
        public string? GenderName { get; set; } = default;
    }
}
