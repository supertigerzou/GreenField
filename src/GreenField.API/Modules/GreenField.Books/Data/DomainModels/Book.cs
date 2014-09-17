﻿
using GreenField.Framework.Data.DomainModels;
using System.Collections.Generic;

namespace GreenField.Books.Data.DomainModels
{
    public class Book : BaseEntity
    {
        private ICollection<BookEntityPicture> _bookEntityPictures;

        public virtual ICollection<BookEntityPicture> EntityEntityPictures
        {
            get { return _bookEntityPictures ?? (_bookEntityPictures = new List<BookEntityPicture>()); }
            protected set { _bookEntityPictures = value; }
        }
        public string Name { get; set; }
        public int AutherId { get; set; }
        public Author Author { get; set; }
    }
}
