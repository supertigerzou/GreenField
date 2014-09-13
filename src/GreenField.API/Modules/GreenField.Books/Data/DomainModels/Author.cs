using GreenField.Framework.Data.DomainModels;
using System.Collections.Generic;

namespace GreenField.Books.Data.DomainModels
{
    public class Author : Person
    {
        private ICollection<Book> _books;
        public Author()
        {
            
        }
        public virtual ICollection<Book> Books
        {
            get { return _books ?? (_books = new List<Book>()); }
            protected set { _books = value; }
        }
    }
}
