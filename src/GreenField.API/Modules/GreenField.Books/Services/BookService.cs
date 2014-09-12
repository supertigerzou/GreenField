using System.Collections.Generic;
using System.Linq;
using GreenField.Books.Data;
using GreenField.Framework.Data;

namespace GreenField.Books.Services
{
    public class BookService
    {
        private readonly IRepository<Book> _bookRepository;

        public BookService()
        {
            _bookRepository = new EfRepository<Book>(new GFDbContext("GFContext"));
        }

        public List<Book> GetAll()
        {
            return _bookRepository.Table.ToList();
        }
    }
}
