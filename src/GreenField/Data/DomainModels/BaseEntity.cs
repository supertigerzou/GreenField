namespace GreenField.Framework.Data.DomainModels
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public int Id { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    }
}
