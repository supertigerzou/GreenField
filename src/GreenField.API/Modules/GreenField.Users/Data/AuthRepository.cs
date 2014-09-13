using GreenField.Framework.Data;
using GreenField.Framework.Data.DomainModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;

namespace GreenField.Users.Data
{
    public class AuthRepository : IDisposable
    {
        private readonly AuthContext _ctx;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthRepository()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_ctx));
        }

        public async Task<ApplicationUser> FindUser(string userName, string password)
        {
            var user = await _userManager.FindAsync(userName, password);
            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }
    }
}
