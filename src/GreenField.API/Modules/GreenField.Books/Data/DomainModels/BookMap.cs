using System.Data.Entity.ModelConfiguration;

namespace GreenField.Books.Data.DomainModels
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            this.ToTable("Book");
            this.HasKey(b => b.Id);

            this.HasRequired(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AutherId);

        }
    }
}
