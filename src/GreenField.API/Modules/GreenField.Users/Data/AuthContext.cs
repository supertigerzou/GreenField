using Microsoft.AspNet.Identity.EntityFramework;

namespace GreenField.Users.Data
{
    public class AuthContext : IdentityDbContext<ApplicationUser>
    {
        public AuthContext()
            : base("GFContext")
        {

        }
    }
}
