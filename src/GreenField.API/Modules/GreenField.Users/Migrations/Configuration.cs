using GreenField.Framework.Data;
using GreenField.Framework.Data.DomainModels;

namespace GreenField.Users.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<AuthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AuthContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  Use the DbSet<T>.AddOrUpdate() helper extension method to avoid creating duplicate seed data.
            context.Users.AddOrUpdate(
              p => p.UserName,
              new ApplicationUser
              {
                  UserName = "victor.zou",
                  PasswordHash = "ADWj64qPNVxOr988AtL7WKaHKkOYSP9LFWUQniZIRxnXFaNJHELTF4kp+FtTnrYe6Q=="
              },
              new ApplicationUser
              {
                  UserName = "unique.lin",
                  PasswordHash = "ADWj64qPNVxOr988AtL7WKaHKkOYSP9LFWUQniZIRxnXFaNJHELTF4kp+FtTnrYe6Q=="
              }
            );

        }
    }
}
