
using GreenField.Books.ViewModels.Media;
using System.Collections.Generic;

namespace GreenField.Books.ViewModels
{
    public class AuthorViewModel
    {
        public string Name { get; set; }

        public IList<PictureModel> PictureModels { get; set; }
    }
}
