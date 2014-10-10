using GreenField.Framework.Data.DomainModels;

namespace GreenField.Framework.Services
{
    public interface IPictureService
    {
        string GetUrlByPicture(EntityPicture picture);
    }
}
