using GreenField.Framework.Data.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GreenField.Books.Data.DomainModels
{
    public class BookEntityPictureMap : EntityTypeConfiguration<BookEntityPicture>
    {
        public BookEntityPictureMap()
        {
            // Primary Key
            this.HasKey(t => new { t.EntityId, t.EntityPictureId });

            // Properties
            this.Property(t => t.EntityId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.EntityPictureId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("BookEntityPicture");
            this.Property(t => t.EntityId).HasColumnName("BookId");
            this.Property(t => t.EntityPictureId).HasColumnName("EntityPictureId");
            this.Property(t => t.Primary).HasColumnName("Primary");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Entity)
                .WithMany(t => t.EntityEntityPictures)
                .HasForeignKey(d => d.EntityId);
            this.HasRequired(t => t.EntityPicture)
                .WithMany()
                .HasForeignKey(d => d.EntityPictureId);
        }
    }
}
