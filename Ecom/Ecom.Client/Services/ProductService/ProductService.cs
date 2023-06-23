
namespace Ecom.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public List<Product> Products { get; set; } = new List<Product>();

        public ProductService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task GetProducts()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product");
            if (response != null && response.Success)
            {
                Products = response.Data;
            }
        }
    }
}