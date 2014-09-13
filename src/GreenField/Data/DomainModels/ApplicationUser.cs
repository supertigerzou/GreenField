using Microsoft.AspNet.Identity.EntityFramework;

namespace GreenField.Framework.Data.DomainModels
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
