using Inventory.Model;

namespace Inventory.Interfaces
{
    public interface ICustomerService
    {
        public Guid AddCustomer(PostCustomer customer);
        public void UpdateCustomer(Guid id, PostCustomer customer);
        public void DeleteCustomer(Guid id);
        public ViewCustomer GetOrdersByCustomers(Guid id);
    }
}