
namespace Ecom.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        public event Action ProductsChanged;
        private readonly HttpClient _httpClient;
        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; } = "Loading Products...";


        public ProductService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
            return response;
        }

        public async Task GetProducts(string categoryUrl = null)
        {
            var url = categoryUrl == null ? "api/product" : $"api/product/category/{categoryUrl}";

            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>(url);
            if (response != null && response.Success)
            {
                Products = response.Data;
                // foreach (var item in Products)
                // {
                //     Console.WriteLine(item.ProductVariants.Count);
                // }
            }

            // Console.WriteLine("ProductsChanged -- " + ProductsChanged);
            ProductsChanged.Invoke();

        }

        public async Task SearchProducts(string searchText)
        {
            var url = $"api/product/search/{searchText}";

            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>(url);
            if (response != null && response.Success)
            {
                Products = response.Data;
            }
            if (Products.Count == 0) Message = "No Products Found ";

            ProductsChanged.Invoke();
        }

        public async Task<List<string>> GetProductsSearchSuggestions(string searchText)
        {
            var url = $"api/product/searchsuggestions/{searchText}";

            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<string>>>(url);

            return response.Data;
        }
    }
}