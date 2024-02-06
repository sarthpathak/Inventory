using Inventory.Implementations;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Filter
{
    internal class InventoryCheckFilterAttribute : Attribute
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is InsufficientInventoryException)
            {
                context.HttpContext.Response.StatusCode = 400; //bad request
                var message = context.Exception.Message;
                context.Result = new JsonResult(new { error = message });
            }
        }
    }
}