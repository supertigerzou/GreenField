using GreenField.Framework.Data.DomainModels;
using System.Data.Entity.Migrations;

namespace GreenField.Books.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Data.BookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Data.BookContext context)
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
