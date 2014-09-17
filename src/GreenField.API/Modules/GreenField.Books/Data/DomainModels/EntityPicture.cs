using GreenField.Framework.Data.DomainModels;
using System.Collections.Generic;

namespace GreenField.Books.Data.DomainModels
{
    //public class BookPicture : EntityPicture<BookEntityPicture>
    //{
    //}


    //public class AuthorPicture : EntityPicture<AuthorEntityPicture>
    //{
    //}

    public partial class EntityPicture : BaseEntity
    {
        private ICollection<EntityEntityPicture<BaseEntity, EntityPicture>> _entityEntityPictures;

        public byte[] ThumbNailPhoto { get; set; }
        public string ThumbnailPhotoFileName { get; set; }
        public byte[] LargePhoto { get; set; }
        public string LargePhotoFileName { get; set; }

        public virtual ICollection<EntityEntityPicture<BaseEntity, EntityPicture>> EntityEntityPictures
        {
            get { return _entityEntityPictures ?? (_entityEntityPictures = new List<EntityEntityPicture<BaseEntity, EntityPicture>>()); }
            protected set { _entityEntityPictures = value; }
        }
    }
}
