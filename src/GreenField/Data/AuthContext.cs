using GreenField.Framework.Data.DomainModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GreenField.Framework.Data
{
    public class AuthContext : IdentityDbContext<ApplicationUser>
    {
        public AuthContext()
            : base("GreenField")
        {

        }

        public AuthContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            
        }
    }
}
