
using Blazored.LocalStorage;

namespace Ecom.Client.Services.CartService
{
    public class CartService : ICartService
    {
        public event Action OnChange;
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _httpClient;

        public CartService(ILocalStorageService localStorageService, HttpClient httpClient)
        {
            this._localStorageService = localStorageService;
            this._httpClient = httpClient;
        }

        public async Task AddToCart(CartItem cartItem)
        {
            var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            var existingCartItem = cart.Find(c => c.ProductId == cartItem.ProductId && c.ProductTypeId == cartItem.ProductTypeId);
            if (existingCartItem != null)
            {
                existingCartItem.Quantity += cartItem.Quantity;
            }
            else
            {
                cart.Add(cartItem);
            }

            await _localStorageService.SetItemAsync("cart", cart);

            OnChange.Invoke();
        }

        public async Task<List<CartItem>> GetCartItems()
        {
            var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            return cart;
        }

        public async Task<List<CartProductResponse>> GetCartProducts()
        {
            var cartItem = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
            var response = await _httpClient.PostAsJsonAsync("api/cart/products", cartItem);

            var cartProducts = await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartProductResponse>>>();
            return cartProducts.Data;
        }

        public async Task RemoveProductFromCart(int productId, int productTypeId)
        {
            var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            var cartItem = cart.Find(c => c.ProductId == productId && c.ProductTypeId == productTypeId);
            if (cartItem != null)
            {
                cart.Remove(cartItem);
                await _localStorageService.SetItemAsync("cart", cart);
                OnChange.Invoke();
            }
        }

        public async Task UpdateQuantity(CartProductResponse cartProductResponse)
        {
            var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                return;
            }

            var cartItem = cart.Find(c => c.ProductId == cartProductResponse.ProductId && c.ProductTypeId == cartProductResponse.ProductTypeId);
            if (cartItem != null)
            {
                cartItem.Quantity = cartProductResponse.Quantity;
                await _localStorageService.SetItemAsync("cart", cart);
                // OnChange.Invoke();
            }
        }
    }
}