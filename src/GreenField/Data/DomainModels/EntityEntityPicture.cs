
using System;
namespace GreenField.Framework.Data.DomainModels
{
    public partial class EntityEntityPicture<TEntity, TEntityPicture> 
    {
        public EntityEntityPicture()
        {
            ModifiedDate = DateTime.Now;
        }

        public int EntityId { get; set; }
        public int EntityPictureId { get; set; }
        public bool Primary { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual TEntity Entity { get; set; }
        public virtual TEntityPicture EntityPicture { get; set; }
    }
}
