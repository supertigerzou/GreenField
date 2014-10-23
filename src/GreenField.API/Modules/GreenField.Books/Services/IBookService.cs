using System.Collections.Generic;
using GreenField.Books.Data.DomainModels;

namespace GreenField.Books.Services
{
    public interface IBookService
    {
        List<Book> GetAll();
    }
}