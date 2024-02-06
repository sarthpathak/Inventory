using Inventory.Domain;
using Inventory.Interfaces;
using Inventory.Model;

namespace Inventory.Implementations
{
    public class CategoryService: ICategoryService
    {

        private readonly IRepository<ProductCategory> _repository;
        public CategoryService(IRepository<ProductCategory> repository)
        {
            _repository = repository;
        }

        public ICollection<ViewCategory> GetAllCategory()
        {
            ICollection<ViewCategory> categoryList = new List<ViewCategory>();
            foreach (var category in _repository.GetAll(null))
            {
                categoryList.Add(new ViewCategory(category));
            }
            return categoryList;
        }

        public Guid AddCategory(PostCategory category)
        {
            var categoryEntity = new ProductCategory()
            {
                Name = category.Name
            };
            _repository.Add(categoryEntity);
            return categoryEntity.Id;
        }

        public ViewCategory GetCategory(Guid id)
        {
            CheckEntityFoundError(id);
            return new ViewCategory(_repository.Get(id));
        }

        public void CheckEntityFoundError(Guid id)
        {
            var customer = _repository.Get(id);
            if (customer != null)
            {
                return;
            }
            else
            {
                throw new EntityNotFoundException("category not found");
            }
        }
    }
}
