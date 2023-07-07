
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace Ecom.Client.Services.CartService
{
    public class CartService : ICartService
    {
        public event Action OnChange;
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authStateProvider;

        public CartService(
            ILocalStorageService localStorageService,
            HttpClient httpClient,
            AuthenticationStateProvider authStateProvider)
        {
            this._localStorageService = localStorageService;
            this._httpClient = httpClient;
            this._authStateProvider = authStateProvider;
        }

        public async Task AddToCart(CartItem cartItem)
        {
            if (await IsUserAuthenticated())
            {
                Console.WriteLine("User is authenticated");
            }
            else
            {
                Console.WriteLine("User is Not authenticated");
            }

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

            // OnChange.Invoke();
            await GetCartItemsCount();
        }

        public async Task<List<CartItem>> GetCartItems()
        {
            await GetCartItemsCount();

            var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            return cart;
        }

        public async Task<List<CartProductResponse>> GetCartProducts()
        {
            if (await IsUserAuthenticated())
            {
                var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<CartProductResponse>>>("api/cart");
                return response.Data;
            }
            else
            {
                var cartItem = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
                if (cartItem == null)
                {
                    return new List<CartProductResponse>();
                }

                var response = await _httpClient.PostAsJsonAsync("api/cart/products", cartItem);

                var cartProducts = await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartProductResponse>>>();
                return cartProducts.Data;
            }

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
                // OnChange.Invoke();
                await GetCartItemsCount();
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

        public async Task StoreCartItems(bool emptyLocalCart = false)
        {
            var localCart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");

            if (localCart == null)
            {
                return;
            }

            await _httpClient.PostAsJsonAsync("api/cart", localCart);

            if (emptyLocalCart)
            {
                await _localStorageService.RemoveItemAsync("cart");
            }
        }

        public async Task GetCartItemsCount()
        {

            if (await IsUserAuthenticated())
            {
                var response = await _httpClient.GetFromJsonAsync<ServiceResponse<int>>("api/cart/count");
                var count = response.Data;

                await _localStorageService.SetItemAsync<int>("cartItemsCount", count);
            }
            else
            {
                var localCart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");
                await _localStorageService.SetItemAsync<int>("cartItemsCount", localCart == null ? 0 : localCart.Count);
            }

            OnChange.Invoke();
        }





        private async Task<bool> IsUserAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }
    }
}