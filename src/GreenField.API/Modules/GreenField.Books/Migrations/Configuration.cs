using System;
using System.Linq;
using GreenField.Books.Data.DomainModels;
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
            var loginUserVictor = new ApplicationUser
                {
                    UserName = "victor.zou",
                    PasswordHash = "ADWj64qPNVxOr988AtL7WKaHKkOYSP9LFWUQniZIRxnXFaNJHELTF4kp+FtTnrYe6Q=="
                };
            var loginUserUnique = new ApplicationUser
                {
                    UserName = "unique.lin",
                    PasswordHash = "ADWj64qPNVxOr988AtL7WKaHKkOYSP9LFWUQniZIRxnXFaNJHELTF4kp+FtTnrYe6Q=="
                };

            context.Users.AddOrUpdate(
                p => p.UserName,
                loginUserVictor,
                loginUserUnique
                );
            context.SaveChanges();

            var authorRhondaByrne = new Author
                {
                    FirstName = "Rhonda",
                    LastName = "Byrne"
                };
            var authorJidduKrishnamurti = new Author
                {
                    FirstName = "Jiddu",
                    LastName = "Jiddu Krishnamurti"
                };
            var authorVictorZou = new Author
                {
                    FirstName = "Victor",
                    LastName = "Zou",
                    LoginUser = loginUserVictor
                };

            context.Authors.AddOrUpdate(
                p => p.Id,
                authorRhondaByrne,
                authorJidduKrishnamurti,
                authorVictorZou
                );
            context.SaveChanges();

            var bookSecret = new Book
                {
                    Author = authorRhondaByrne,
                    Name = "The Secret"
                };
            var bookFreedomFromTheKnown = new Book
                {
                    Author = authorJidduKrishnamurti,
                    Name = "Freedom from the Known"
                };

            context.Books.AddOrUpdate(
                b => b.Id,
                bookSecret,
                bookFreedomFromTheKnown
                );
        }
    }
}
