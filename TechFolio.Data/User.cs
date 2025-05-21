using Microsoft.AspNetCore.Identity;

namespace TechFolio.Server
{
    public class User : IdentityUser
    {
        public UserRole role { get; set; }
    }
}
