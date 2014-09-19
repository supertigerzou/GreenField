
namespace GreenField.Framework.Data.DomainModels
{
    public class Person : BaseEntity
    {
        public string PersonType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public ApplicationUser LoginUser { get; set; }
    }
}
