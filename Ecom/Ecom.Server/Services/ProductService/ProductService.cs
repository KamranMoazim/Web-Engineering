

using Ecom.Server.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            this._context = context;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>();
            var product = await _context.Products
                .Include(p => p.ProductVariants)
                .ThenInclude(v => v.ProductType)
                .FirstOrDefaultAsync(p => p.Id == productId);
            if (product == null)
            {
                response.Success = false;
                response.Message = "Sorry, Product not found.";
                return response;
            }
            else
            {
                response.Data = product;
                return response;
            }
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var products = await _context.Products.ToListAsync();
            var response = new ServiceResponse<List<Product>>()
            {
                Data = products,
            };


            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl)
        {
            var products = await _context.Products.Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower())).ToListAsync();

            var response = new ServiceResponse<List<Product>>()
            {
                Data = products,
            };

            return response;
        }

        public async Task<ServiceResponse<List<string>>> GetProductsSearchSuggestions(string searchText)
        {
            List<Product> products = await FindProductsBySearchText(searchText);

            List<string> result = new List<string>();

            foreach (var product in products)
            {
                if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }

                if (product.Description != null)
                {
                    var punctuation = product.Description.Where(char.IsPunctuation)
                        .Distinct().ToArray();

                    var words = product.Description.Split()
                        .Select(s => s.Trim(punctuation));

                    foreach (var word in words)
                    {
                        if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase) && !result.Contains(word))
                        {
                            result.Add(word);
                        }
                    }

                }
            }

            return new ServiceResponse<List<string>>()
            {
                Data = result
            };
        }

        public async Task<ServiceResponse<List<Product>>> SearchProducts(string searchText)
        {
            List<Product> products = await FindProductsBySearchText(searchText);

            var response = new ServiceResponse<List<Product>>()
            {
                Data = products,
            };

            return response;
        }

        private async Task<List<Product>> FindProductsBySearchText(string searchText)
        {
            return await _context.Products
                            .Where(p =>
                                p.Title.ToLower().Contains(searchText.ToLower())
                                ||
                                p.Description.ToLower().Contains(searchText.ToLower())
                            )
                            .Include(p => p.ProductVariants)
                            .ToListAsync();
        }
    }
}