using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenField.Framework.Data;

namespace GreenField.Books.Data
{
    public class BookContext : GFDbContext
    {
        public BookContext()
            : base("GFContext")
        {
            
        }

        public virtual IDbSet<Book> Books { get; set; }
    }
}
