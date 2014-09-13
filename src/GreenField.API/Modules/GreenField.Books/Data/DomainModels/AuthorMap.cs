using System.Data.Entity.ModelConfiguration;

namespace GreenField.Books.Data.DomainModels
{
    public class AuthorMap : EntityTypeConfiguration<Author>
    {
        public AuthorMap()
        {
            this.ToTable("Author");
            this.HasKey(b => b.Id);

            this.HasOptional(a => a.LoginUserId);

        }
    }
}
