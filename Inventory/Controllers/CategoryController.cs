using Microsoft.AspNetCore.Mvc;
using Inventory.Domain;
using System.Runtime.InteropServices;
using Inventory.DTO;
using Inventory.Interfaces;
using Inventory.Model;

namespace Inventory.Controllers
{

    [ApiController]
    [Route("categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryRepository;
        public CategoryController(ICategoryService categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("getAll")]
        public ICollection<ViewCategory> GetAllCategory()
        {
            return _categoryRepository.GetAllCategory();
        }

        [HttpGet("get/{id}")]
        public ViewCategory GetCategory(Guid id)
        {
            return _categoryRepository.GetCategory(id);
        }

        [HttpPost("add")]
        public Guid AddCategory(PostCategory category)
        {
            return _categoryRepository.AddCategory(category);
        }
    }



}

    


    
    


        
