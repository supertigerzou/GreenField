using System.Data.Entity.ModelConfiguration;

namespace GreenField.Books.Data.DomainModels
{
    public class AuthorMap : EntityTypeConfiguration<Author>
    {
        public AuthorMap()
        {
            ToTable("Author");
            HasKey(b => b.Id);

            HasOptional(a => a.LoginUser);
        }
    }
}
