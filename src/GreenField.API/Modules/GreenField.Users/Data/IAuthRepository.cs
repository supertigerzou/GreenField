using System.Threading.Tasks;
using GreenField.Framework.Data.DomainModels;
using GreenField.Users.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GreenField.Users.Data
{
    public interface IAuthRepository
    {
        Task<IdentityUser> FindUser(string userName, string password);
        Task<IdentityUser> FindAsync(UserLoginInfo loginInfo);
        Task<IdentityResult> CreateAsync(IdentityUser user);
        Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login);
        Task<IdentityResult> RegisterUser(UserModel userModel);
        Client FindClient(string clientId);
    }
}