using System;
namespace GreenField.Framework.Data.DomainModels
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            ModifiedDate = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public int Id { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
