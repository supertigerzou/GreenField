using GreenField.Books.Data;
using GreenField.Books.Data.DomainModels;
using GreenField.Framework.Data;
using System.Collections.Generic;
using System.Linq;

namespace GreenField.Books.Services
{
    public interface IBookService
    {
        List<Book> GetAll();
    }

    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;

        public BookService()
        {
            _bookRepository = new EfRepository<Book>(new BookContext());
        }

        public List<Book> GetAll()
        {
            return _bookRepository.Table.ToList();
        }
    }
}
