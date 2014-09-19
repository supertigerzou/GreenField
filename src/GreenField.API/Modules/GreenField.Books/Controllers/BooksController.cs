using GreenField.Books.Data.DomainModels;
using System.Collections.Generic;
using System.Web.Http;

namespace GreenField.Books.Controllers
{
    [RoutePrefix("api/Books")]
    public class BooksController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(new List<Book>{new Book
                {
                    Name = "test1",
                    Id = 1,
                    AutherId = 1
                }});
        }
    }
}
