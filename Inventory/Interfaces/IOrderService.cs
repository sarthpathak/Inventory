using Inventory.Model;

namespace Inventory.Interfaces
{
    public interface IOrderService
    {
        public Guid AddOrder(PostOrder order);
        public void DeleteOrder(Guid id);
    }
}