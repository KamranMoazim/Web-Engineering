

namespace Ecom.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        public List<Category> Categories { get; set; } = new List<Category>();

        public CategoryService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task GetCategories()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/category");

            if (response != null && response.Success)
            {
                Categories = response.Data;
            }

        }
    }
}