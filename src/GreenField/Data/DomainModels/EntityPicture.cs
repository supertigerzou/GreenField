
using System.Collections.Generic;

namespace GreenField.Framework.Data.DomainModels
{
    public partial class EntityPicture<TEntity> : BaseEntity
    {
        private ICollection<TEntity> _entityEntityPictures;

        public byte[] ThumbNailPhoto { get; set; }
        public string ThumbnailPhotoFileName { get; set; }
        public byte[] LargePhoto { get; set; }
        public string LargePhotoFileName { get; set; }

        public virtual ICollection<TEntity> BookBookPictures
        {
            get { return _entityEntityPictures ?? (_entityEntityPictures = new List<TEntity>()); }
            protected set { _entityEntityPictures = value; }
        }
    }
}
