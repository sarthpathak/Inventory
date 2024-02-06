using Inventory.Domain;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Model
{
    public class ViewCustomer
    {
    
        public ICollection<ViewOrder>? Orders { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
  
        public string Email { get; set; }
    
        public string Phone { get; set; }

       

        public ViewCustomer() { }
        public ViewCustomer(Customer customer, ICollection<ViewOrder>? orders)
        {
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email;
            Phone = customer.Phone;
            Orders = orders;
        }
    }
}
