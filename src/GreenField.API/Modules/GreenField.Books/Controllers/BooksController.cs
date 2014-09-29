using GreenField.Books.Data.DomainModels;
using System.Linq;
using System.Web.Http;
using GreenField.Books.Services;
using GreenField.Books.ViewModels;

namespace GreenField.Books.Controllers
{
    [RoutePrefix("api/Books")]
    public class BooksController : ApiController
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_bookService.GetAll().Select(book => new BookViewModel
                {
                    Name = book.Name,
                    Auther = book.Author.FirstName + " " + book.Author.LastName
                }));
        }
    }
}
