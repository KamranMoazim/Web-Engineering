
namespace Ecom.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        public event Action ProductsChanged;
        private readonly HttpClient _httpClient;
        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; } = "Loading Products...";
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;

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
            var url = categoryUrl == null ? "api/product/featured" : $"api/product/category/{categoryUrl}";

            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>(url);
            if (response != null && response.Success)
            {
                Products = response.Data;
            }

            CurrentPage = 1;
            PageCount = 0;

            if (Products.Count == 0)
            {
                Message = "No Products Found ";
            }

            ProductsChanged.Invoke();

        }

        public async Task SearchProducts(string searchText, int page)
        {
            var url = $"api/product/search/{searchText}/{page}";

            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<ProductSearchResult>>(url);
            if (response != null && response.Success)
            {
                Products = response.Data.Products;
                CurrentPage = response.Data.CurrentPage;
                PageCount = response.Data.Pages;
            }

            LastSearchText = searchText;


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