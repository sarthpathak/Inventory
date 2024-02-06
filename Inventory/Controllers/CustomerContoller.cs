using Inventory.Interfaces;
using Inventory.Model;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("getDetails/{id}")]
        public ViewCustomer GetAllDetails(Guid id)
        {
            return _customerService.GetOrdersByCustomers(id);
        }

        [HttpPost("add")]
        public Guid AddCustomer(PostCustomer customer)
        {
            return _customerService.AddCustomer(customer);
        }

        [HttpDelete("delete/{id}")]
        public void DeleteCustomer(Guid id)
        {
            _customerService.DeleteCustomer(id);
        }

        [HttpPatch("update/{id}")]
        public void UpdateCustomer(Guid id, PostCustomer customer)
        {
            _customerService.UpdateCustomer(id, customer);
        }
    }
}
