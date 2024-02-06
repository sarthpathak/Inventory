using Inventory.Domain;
using Inventory.Interfaces;
using Inventory.Model;

namespace Inventory.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repository;
        private readonly IRepository<Order> _orderRepo;
        private readonly IRepository<OrderProduct> _orderProductRepo;
        private readonly IRepository<Product> _productRepo;

        public CustomerService(IRepository<Customer> repository, IRepository<Order> orderRepo, IRepository<OrderProduct> orderProductRepo, IRepository<Product> productRepo)
        {
            _repository = repository;
            _orderRepo = orderRepo;
            _orderProductRepo = orderProductRepo;
            _productRepo = productRepo;
        }

        public Guid AddCustomer(PostCustomer customer)
        {
            var customerEntity = new Customer()
            {
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.PhoneNumber,
            };
            _repository.Add(customerEntity);
            return customerEntity.Id;
        }

        public void DeleteCustomer(Guid id)
        {
            CheckEntityFoundError(id);
            _repository.Delete(_repository.Get(id));
        }

        public ViewCustomer GetOrdersByCustomers(Guid id)
        {
            CheckEntityFoundError(id);
            var orders =
                (from order in _orderRepo.GetAll(null).ToList()
                 where order.CustomerId == id
                 join product in _orderProductRepo.GetAll(null) on order.Id equals product.OrderId into orderProducts
                 from joined in orderProducts.DefaultIfEmpty()
                 select new ViewOrder()
                 {
                     ProductName = _productRepo.Get(joined.ProductId).Name, // Handle potential nulls
                     ProductQuantity = joined?.Quantity ?? 0 // Set default for null Quantity
                 }).ToList();
            return new ViewCustomer(_repository.Get(id), orders);

        }

        public void UpdateCustomer(Guid id, PostCustomer customer)
        {
            CheckEntityFoundError(id);
            _repository.Update(new Customer()
            {
                Id = id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.PhoneNumber,
                Email = customer.Email,
            });
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
                throw new EntityNotFoundException("customer not found");
            }
        }
    }
}
