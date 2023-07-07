

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
        public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> GetCartProducts([FromBody] List<CartItem> cartItems)
        {
            var serviceResponse = await _cartService.GetCartProducts(cartItems);
            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> StoreCartItems([FromBody] List<CartItem> cartItems)
        {
            var serviceResponse = await _cartService.StoreCartItems(cartItems);
            return Ok(serviceResponse);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> GetCartItemsCount()
        {
            var serviceResponse = await _cartService.GetCartItemsCount();
            return Ok(serviceResponse);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> GetDbCartProducts()
        {
            var serviceResponse = await _cartService.GetDbCartProducts();
            return Ok(serviceResponse);
        }
    }
}