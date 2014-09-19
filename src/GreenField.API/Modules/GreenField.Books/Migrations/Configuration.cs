using GreenField.Books.Data.DomainModels;
using GreenField.Framework.Data.DomainModels;
using GreenField.Framework.Helpers;
using System.Data.Entity.Migrations;
using System.IO;

namespace GreenField.Books.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<Data.BookContext>
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
            var authorYuanJieZheng = new Author
            {
                FirstName = "YuanJie",
                LastName = "Zheng"
            };
            var authorScottOdell = new Author
            {
                FirstName = "Scott",
                LastName = "O'Dell"
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
                authorYuanJieZheng,
                authorScottOdell,
                authorVictorZou
                );
            context.SaveChanges();

            // http://www.amazon.com/Secret-Rhonda-Byrne/dp/1582701709
            var bookSecret = new Book
                {
                    Author = authorRhondaByrne,
                    Name = "The Secret"
                };
            // http://www.amazon.com/Freedom-Known-Jiddu-Krishnamurti/dp/0060648082
            var bookFreedomFromTheKnown = new Book
                {
                    Author = authorJidduKrishnamurti,
                    Name = "Freedom from the Known"
                };
            // http://www.amazon.com/The-Book-Life-Meditations-Krishnamurti/dp/0060648791
            var bookTheBookOfLife = new Book
            {
                Author = authorJidduKrishnamurti,
                Name = "The Book of Life"
            };
            // http://www.amazon.com/Think-These-Things-Jiddu-Krishnamurti/dp/0060916095
            var bookThinkOnTheseThings = new Book
            {
                Author = authorJidduKrishnamurti,
                Name = "Think on These Things"
            };
            // http://www.amazon.com/On-Love-Loneliness-Jiddu-Krishnamurti/dp/0062510134
            var bookOnLoveAndLoneliness = new Book
            {
                Author = authorJidduKrishnamurti,
                Name = "On Love and Loneliness"
            };
            // http://www.amazon.com/Stories-Shuke-Beita-Chinese/dp/7539175745
            var bookTheStoriesOfShukeAndBeita = new Book
            {
                Author = authorYuanJieZheng,
                Name = "The Stories of Shuke and Beita"
            };
            // http://www.amazon.com/Stories-about-Pi-Pilu-Chinese/dp/7539175761
            var bookStoriesAboutPiPilu = new Book
            {
                Author = authorYuanJieZheng,
                Name = "Stories about Pi Pilu"
            };
            // http://www.amazon.com/Stories-about-Lu-Xixi-Chinese/dp/7539175753
            var bookStoriesAboutLuXixi = new Book
            {
                Author = authorYuanJieZheng,
                Name = "Stories about Lu Xixi"
            };
            // http://www.amazon.com/Island-Blue-Dolphins-Scott-ODell/dp/0547328613
            var bookIslandOfTheBlueDolphins = new Book
            {
                Author = authorScottOdell,
                Name = "Island of the Blue Dolphins"
            };
            // http://www.amazon.com/Sing-Down-Moon-Scott-ODell/dp/0547406320
            var bookSingDownTheMoon = new Book
            {
                Author = authorScottOdell,
                Name = "Sing Down the Moon"
            };
            // http://www.amazon.com/Black-Pearl-Scott-ODell/dp/0547334001
            var bookTheBlackPearl = new Book
            {
                Author = authorScottOdell,
                Name = "The Black Pearl"
            };

            context.Books.AddOrUpdate(
                b => b.Id,
                bookSecret,
                bookFreedomFromTheKnown,
                bookTheBookOfLife,
                bookThinkOnTheseThings,
                bookOnLoveAndLoneliness,
                bookTheStoriesOfShukeAndBeita,
                bookStoriesAboutPiPilu,
                bookStoriesAboutLuXixi,
                bookIslandOfTheBlueDolphins,
                bookSingDownTheMoon,
                bookTheBlackPearl
                );
            context.SaveChanges();

            const string sampleImagePathBase = "~/Migrations/Images/";
            var pictureSecret1 = new EntityPicture
                {
                    LargePhotoFileName = "secret_1_large.jpg",
                    LargePhoto = File.ReadAllBytes(WebHelper.MapPath(sampleImagePathBase + "secret_1_large.jpg")),
                    ThumbnailPhotoFileName = "secret_1_small.jpg",
                    ThumbNailPhoto = File.ReadAllBytes(WebHelper.MapPath(sampleImagePathBase + "secret_1_small.jpg"))
                };
            var pictureSecret2 = new EntityPicture
            {
                LargePhotoFileName = "secret_2_large.jpg",
                LargePhoto = File.ReadAllBytes(WebHelper.MapPath(sampleImagePathBase + "secret_2_large.jpg")),
                ThumbnailPhotoFileName = "secret_2_small.jpg",
                ThumbNailPhoto = File.ReadAllBytes(WebHelper.MapPath(sampleImagePathBase + "secret_2_small.jpg"))
            };
            var pictureSecret3 = new EntityPicture
            {
                LargePhotoFileName = "secret_3_large.jpg",
                LargePhoto = File.ReadAllBytes(WebHelper.MapPath(sampleImagePathBase + "secret_3_large.jpg")),
                ThumbnailPhotoFileName = "secret_3_small.jpg",
                ThumbNailPhoto = File.ReadAllBytes(WebHelper.MapPath(sampleImagePathBase + "secret_3_small.jpg"))
            };
            
            var pictureRhondaByrne1 = new EntityPicture
            {
                LargePhotoFileName = "RhondaByrne_1_large.jpg",
                LargePhoto = File.ReadAllBytes(WebHelper.MapPath(sampleImagePathBase + "RhondaByrne_1_large.jpg")),
                ThumbnailPhotoFileName = "RhondaByrne_1_small.jpg",
                ThumbNailPhoto = File.ReadAllBytes(WebHelper.MapPath(sampleImagePathBase + "RhondaByrne_1_small.jpg"))
            };
            var pictureRhondaByrne2 = new EntityPicture
            {
                LargePhotoFileName = "RhondaByrne_2_large.jpg",
                LargePhoto = File.ReadAllBytes(WebHelper.MapPath(sampleImagePathBase + "RhondaByrne_2_large.jpg")),
                ThumbnailPhotoFileName = "RhondaByrne_2_small.jpg",
                ThumbNailPhoto = File.ReadAllBytes(WebHelper.MapPath(sampleImagePathBase + "RhondaByrne_2_small.jpg"))
            };
            context.EntityPictures.AddOrUpdate(
                bp => bp.Id,
                pictureSecret1,
                pictureSecret2,
                pictureSecret3,
                pictureRhondaByrne1,
                pictureRhondaByrne2
                );
            context.SaveChanges();

            var bookPictureMapping1 = new BookEntityPicture
                {
                    Entity = bookSecret,
                    EntityPicture = pictureSecret1,
                    Primary = true
                };
            var bookPictureMapping2 = new BookEntityPicture
            {
                Entity = bookSecret,
                EntityPicture = pictureSecret2,
                Primary = false
            };
            var bookPictureMapping3 = new BookEntityPicture
            {
                Entity = bookSecret,
                EntityPicture = pictureSecret3,
                Primary = false
            };

            context.BookEntityPictures.AddOrUpdate(
                bbp => new { bbp.EntityId, bbp.EntityPictureId },
                bookPictureMapping1, bookPictureMapping2, bookPictureMapping3
                );
            context.SaveChanges();

            var authorPictureMapping1 = new AuthorEntityPicture
            {
                Entity = authorRhondaByrne,
                EntityPicture = pictureRhondaByrne1,
                Primary = true
            };
            var authorPictureMapping2 = new AuthorEntityPicture
            {
                Entity = authorRhondaByrne,
                EntityPicture = pictureRhondaByrne2,
                Primary = false
            };

            context.AuthorEntityPictures.AddOrUpdate(
                bbp => new { bbp.EntityId, bbp.EntityPictureId },
                authorPictureMapping1, authorPictureMapping2
                );
            
        }
    }
}
