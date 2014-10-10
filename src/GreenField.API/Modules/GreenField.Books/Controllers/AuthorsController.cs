using GreenField.Books.Data.DomainModels;
using System.Linq;
using System.Web.Http;
using GreenField.Books.Services;
using GreenField.Books.ViewModels;
using GreenField.Books.ViewModels.Media;
using GreenField.Framework.Services;

namespace GreenField.Books.Controllers
{
    [RoutePrefix("api/Authors")]
    public class AuthorsController : ApiController
    {
        private readonly IAuthorService _authorService;
        private readonly IPictureService _pictureService;

        public AuthorsController(IAuthorService authorService, IPictureService pictureService)
        {
            _authorService = authorService;
            _pictureService = pictureService;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_authorService.GetAll().Select(author => new AuthorViewModel
                {
                    Name = string.Format("{0} {1}", author.FirstName, author.LastName),
                    PictureModels = author.EntityEntityPictures.Select(pic => new PictureModel
                        {
                            ImageUrl = _pictureService.GetUrlByPicture(pic.EntityPicture)
                        }).ToList()
                }));
        }
    }
}
