using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoviesWebApp.Models
{
    public class UserLogin
    {


        [Required]
        [MaxLength(60), MinLength(3)]
        public string Username { get; set; } = string.Empty;
        [Required]
        [MaxLength(100), MinLength(10)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(30), MinLength(4)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; }
    }
}
