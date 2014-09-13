using GreenField.Framework.Data.DomainModels;

namespace GreenField.Books.Data.DomainModels
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public int AutherId { get; set; }
        public Author Author { get; set; }

    }
}
