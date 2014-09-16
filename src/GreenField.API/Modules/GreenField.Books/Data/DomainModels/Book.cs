using GreenField.Framework.Data.DomainModels;
using System.Collections.Generic;

namespace GreenField.Books.Data.DomainModels
{
    public class Book : BaseEntity
    {
        private ICollection<BookBookPicture> _bookBookPictures;

        public string Name { get; set; }
        public int AutherId { get; set; }
        public Author Author { get; set; }

        public virtual ICollection<BookBookPicture> BookBookPictures
        {
            get { return _bookBookPictures ?? (_bookBookPictures = new List<BookBookPicture>()); }
            protected set { _bookBookPictures = value; }
        }
    }
}
