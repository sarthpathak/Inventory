using System.ComponentModel.DataAnnotations;

namespace Inventory.Domain
{
    public class Product:BaseDomain
    {
        [Key]
      
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Measurement { get; set; }

        public  virtual ProductCategory Category { get; set; } // Navigation property

        public virtual ICollection<OrderProduct>? Orders { get; }




    }
}
