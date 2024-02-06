using Inventory.Model;

namespace Inventory.Interfaces
{
    public interface ICategoryService
    {
        public ICollection<ViewCategory> GetAllCategory();
        public Guid AddCategory(PostCategory category);
        public ViewCategory GetCategory(Guid id);
    }
}
