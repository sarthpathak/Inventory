using System.ComponentModel.DataAnnotations;

namespace Inventory.Domain
{
    public class Customer:BaseDomain
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
    }
}
