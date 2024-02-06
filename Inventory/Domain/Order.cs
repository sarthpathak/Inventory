using System.ComponentModel.DataAnnotations;

namespace Inventory.Domain
{
    public class Order:BaseDomain
    {
       
      
        public Guid CustomerId { get; set; }
      
        //public int Quantity { get; set; }

        public virtual ICollection<OrderProduct> Products { get; set; }
        public string Status { get; set; }


        public virtual Customer Customer { get; set; } // Navigation property
       
    }
}
