﻿using GreenField.Books.Data;
using GreenField.Books.Data.DomainModels;
using GreenField.Framework.Data;
using System.Collections.Generic;
using System.Linq;

namespace GreenField.Books.Services
{
    public interface IAuthorService
    {
        List<Author> GetAll();
    }

    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;

        public AuthorService()
        {
            _authorRepository = new EfRepository<Author>(new BookContext());
        }

        public List<Author> GetAll()
        {
            return _authorRepository.Table.ToList();
        }
    }
}
