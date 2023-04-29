using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWebApp.Models
{
    public class UserRegister
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        [MaxLength(60),MinLength(3)]
        [Column(TypeName =("nvarchar(60)"))]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(60), MinLength(3)]
        [Column(TypeName = ("varchar(60)"))]
        public string Username { get; set; } = string.Empty;
        [Required]
        [MaxLength(100), MinLength(10)]
        [Column(TypeName = ("varchar(100)"))]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(30), MinLength(4)]
        [Column(TypeName = ("varchar(30)"))]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        public bool IsActive { get; set; }=true;
    }
}
