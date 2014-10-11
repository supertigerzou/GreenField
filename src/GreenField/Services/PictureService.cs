using System.Web.Hosting;
using GreenField.Framework.Data.DomainModels;
using GreenField.Framework.Helpers;
using System.IO;

namespace GreenField.Framework.Services
{
    public class PictureService : IPictureService
    {
        private readonly IWebHelper _webHelper;

        public PictureService(IWebHelper webHelper)
        {
            _webHelper = webHelper;
        }

        public string GetUrlByPicture(EntityPicture picture)
        {
            var thumbnailFilePath = GetFileLocalPath(picture.ThumbnailPhotoFileName);
            if (!File.Exists(thumbnailFilePath))
            {
                File.WriteAllBytes(thumbnailFilePath, picture.ThumbNailPhoto);
            }

            return HostingEnvironment.ApplicationVirtualPath + "content/images/thumbs/" + picture.ThumbnailPhotoFileName;
        }

        protected virtual string GetFileLocalPath(string fileName)
        {
            var filesDirectoryPath = _webHelper.MapPath("~/content/images/thumbs");

            var filePath = Path.Combine(filesDirectoryPath, fileName);
            return filePath;
        }
    }
}
