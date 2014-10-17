using GreenField.Framework.Data.DomainModels;

namespace GreenField.Framework.Services
{
    public enum PictureType
    {
        Thumbnail,
        Full
    }
    public interface IPictureService
    {
        string GetUrlByPicture(EntityPicture picture, PictureType pictureType);
    }
}
