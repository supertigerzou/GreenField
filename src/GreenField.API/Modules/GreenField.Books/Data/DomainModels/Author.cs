using GreenField.Framework.Data.DomainModels;
using System.Collections.Generic;

namespace GreenField.Books.Data.DomainModels
{
    public class Author : Person
    {
        private ICollection<Book> _books;
        private ICollection<AuthorEntityPicture> _authorEntityPictures;

        public virtual ICollection<AuthorEntityPicture> EntityEntityPictures
        {
            get { return _authorEntityPictures ?? (_authorEntityPictures = new List<AuthorEntityPicture>()); }
            protected set { _authorEntityPictures = value; }
        }

        public virtual ICollection<Book> Books
        {
            get { return _books ?? (_books = new List<Book>()); }
            protected set { _books = value; }
        }
    }
}
