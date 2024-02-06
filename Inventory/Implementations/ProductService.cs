using Inventory.Domain;
using Inventory.DTO;
using Inventory.Interfaces;
using Inventory.Model;



using Inventory.Reposits;
using System;

namespace Inventory.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly IRepository<ProductCategory> _catrepository;

        public ProductService(IRepository<Product> repository, IRepository<ProductCategory> catrepository)
        {
            _repository = repository;
            _catrepository = catrepository;
        }

        public ICollection<ViewProduct> GetAllProduct()
        {
            ICollection<ViewProduct> productList = new List<ViewProduct>();
            var prods = _repository.GetAll(null);
            foreach (var product in prods)
            {
                productList.Add(new ViewProduct(product, _catrepository));
            }
            return productList;
        }

        public Guid AddProduct(PostProduct product)
        {
            var productEntity = new Product()
            {
                Name = product.Name,
                Quantity = product.Quantity,
                Measurement = product.Measurement,
                CategoryId = product.CategoryId,
            };

            _repository.Add(productEntity);
            return productEntity.Id;
        }

        public void DeleteProduct(Guid id)
        {
            CheckEntityFoundError(id);
            _repository.Delete(_repository.Get(id));
        }

        public ViewProduct GetProductById(Guid id)
        {
            CheckEntityFoundError(id);
            return new ViewProduct(_repository.Get(id), _catrepository);
        }

        public void UpdateProduct(Guid id, PostProduct product)
        {
            CheckEntityFoundError(id);
            var prod = new Product()
            {
                Id = id,
                Name = product.Name,
                Quantity = product.Quantity,
                Measurement = product.Measurement,
                CategoryId = product.CategoryId,
            };
            _repository.Update(prod);
        }

        private void CheckEntityFoundError(Guid id)
        {
            throw new NotImplementedException();
        }


        //
        public void CheckProductNotfound(Guid id)
        {
            var customer = _repository.Get(id);
            if (customer != null)
            {
                return;
            }
            else
            {
                throw new EntityNotFoundException("product not found");
            }
        }

    }
}
