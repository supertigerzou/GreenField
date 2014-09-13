
using Microsoft.AspNet.Identity.EntityFramework;

namespace GreenField.Framework.Data.DomainModels
{
    public class Person : BaseEntity
    {
        public Person()
        {
            
        }
        public string PersonType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginUserId { get; set; }
        public ApplicationUser LoginUser { get; set; }
    }
}
