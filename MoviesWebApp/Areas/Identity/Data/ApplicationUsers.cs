using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MoviesWebApp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUsers class
public class ApplicationUsers : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName { get; set; }
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; }
    [PersonalData]
    [Column(TypeName = "nvarchar(50)")]
    public string UserRole { get; set; }
}

