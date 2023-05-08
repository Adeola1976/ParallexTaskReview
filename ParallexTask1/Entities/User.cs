using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ParallexTask1.Entities
{
    public class User : IdentityUser
    { 
     
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
