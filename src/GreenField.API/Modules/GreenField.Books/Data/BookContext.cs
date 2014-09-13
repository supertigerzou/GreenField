using GreenField.Books.Data.DomainModels;
using GreenField.Framework.Data;
using System.Data.Entity;

namespace GreenField.Books.Data
{
    public class BookContext : GFDbContext
    {
        public BookContext()
            : base("GFContext")
        {
            
        }

        public virtual IDbSet<Book> Books { get; set; }

        public virtual IDbSet<Author> Authors { get; set; }
    }
}
