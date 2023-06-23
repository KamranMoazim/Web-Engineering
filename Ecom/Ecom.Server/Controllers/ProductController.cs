
using Ecom.Server.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly DataContext context;

        public ProductController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await context.Products.ToListAsync();
            return Ok(products);
        }
    }
}