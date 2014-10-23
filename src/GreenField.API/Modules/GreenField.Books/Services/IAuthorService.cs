using System.Collections.Generic;
using GreenField.Books.Data.DomainModels;

namespace GreenField.Books.Services
{
    public interface IAuthorService
    {
        List<Author> GetAll();
        Author GetById(long authorId);
    }
}