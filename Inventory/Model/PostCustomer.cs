using System.ComponentModel.DataAnnotations;

namespace Inventory.Model
{
    public class PostCustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
