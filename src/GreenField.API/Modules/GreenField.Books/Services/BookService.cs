using GreenField.Books.Data;
using GreenField.Books.Data.DomainModels;
using GreenField.Framework.Caching;
using GreenField.Framework.Data;
using System.Collections.Generic;
using System.Linq;

namespace GreenField.Books.Services
{
    public class BookService : IBookService
    {
        private const string BooksAllKey = "GF.book.all";

        private readonly IRepository<Book> _bookRepository;
        private readonly ICacheManager _cacheManager;

        public BookService(ICacheManager cacheManager)
        {
            _bookRepository = new EfRepository<Book>(new BookContext());
            _cacheManager = cacheManager;
        }

        public List<Book> GetAll()
        {
            return _cacheManager.Get(BooksAllKey, () => _bookRepository.Table.ToList());
        }
    }
}
