using Inventory.Domain;
using Inventory.Reposits;

namespace Inventory.DTO


{
    public class ViewProduct
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Measurement { get; set; }

        public string Category {  get; set; }

        public ViewProduct(Product product, Interfaces.IRepository<ProductCategory> _catrepository) { }
        public ViewProduct(Product product, Repository<ProductCategory> _catrepository)
        {
            Name = product.Name;
            Measurement = product.Measurement;
            Quantity = product.Quantity;
            Category = _catrepository.Get(product.CategoryId).Name;
        }
    }
}
