
using Ecom.Server.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> GetCategories()
        {
            var response = await _categoryService.GetCategories();
            return Ok(response);
        }

    }
}