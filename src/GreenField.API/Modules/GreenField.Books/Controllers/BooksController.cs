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
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(new BookService().GetAll().Select(book => new BookViewModel
                {
                    Name = book.Name,
                    Auther = book.Author.FirstName + " " + book.Author.LastName
                }));
        }
    }
}
