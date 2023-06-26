

using Ecom.Server.Services.CartService;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("products")]
        public async Task<ActionResult<List<CartProductResponse>>> GetCartProducts([FromBody] List<CartItem> cartItems)
        {
            var serviceResponse = await _cartService.GetCartProducts(cartItems);
            return Ok(serviceResponse);
        }
    }
}