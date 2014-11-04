using GreenField.Framework.Data.DomainModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GreenField.Framework.Data
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("GreenField")
        {

        }

        public AuthContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
