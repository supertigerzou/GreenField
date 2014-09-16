using System.Data.Entity.ModelConfiguration;

namespace GreenField.Books.Data.DomainModels
{
    public class BookPictureMap : EntityTypeConfiguration<BookPicture>
    {
        public BookPictureMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ThumbnailPhotoFileName)
                .HasMaxLength(50);

            this.Property(t => t.LargePhotoFileName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("EntityPicture");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ThumbNailPhoto).HasColumnName("ThumbNailPhoto");
            this.Property(t => t.ThumbnailPhotoFileName).HasColumnName("ThumbnailPhotoFileName");
            this.Property(t => t.LargePhoto).HasColumnName("LargePhoto");
            this.Property(t => t.LargePhotoFileName).HasColumnName("LargePhotoFileName");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}
