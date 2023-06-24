
namespace Ecom.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public List<Product> Products { get; set; } = new List<Product>();

        public event Action ProductsChanged;

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

            ProductsChanged.Invoke();

        }
    }
}