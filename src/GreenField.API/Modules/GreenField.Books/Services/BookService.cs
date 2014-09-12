using System.Collections.Generic;
using System.Linq;
using GreenField.Books.DomainModels;
using GreenField.Framework.Data;

namespace GreenField.Books.Services
{
    public class BookService
    {
        private readonly IRepository<Book> _bookRepository;

        public BookService()
        {
            this._bookRepository = new EfRepository<Book>(new GFObjectContext("GFContext"));
        }

        public List<Book> GetAll()
        {
            return _bookRepository.Table.ToList();
        }
    }
}
