using System;
using System.Collections.Generic;
using System.Linq;
using GreenField.Books.Data;
using GreenField.Books.Data.DomainModels;
using GreenField.Framework.Data;

namespace GreenField.Books.Services
{
    public class BookService
    {
        private readonly IRepository<Book> _bookRepository;

        public BookService()
        {
            _bookRepository = new EfRepository<Book>(new BookContext());
        }

        public List<Book> GetAll()
        {
            try
            {
                return _bookRepository.Table.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
