using Inventory.Domain;

namespace Inventory.Model
{
    public class ViewCategory
    {
        public string Name { get; set; }

        public ViewCategory() { }
        public ViewCategory(ProductCategory category)
        {
            Name = category.Name;
        }
    }
}
