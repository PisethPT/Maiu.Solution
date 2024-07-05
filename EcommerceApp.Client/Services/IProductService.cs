using EcommerceApp.Client.Models;

namespace EcommerceApp.Client.Services;
public interface IProductService
{
    Task<List<Category>> GetCategoriesAsync();
    Task<ResponseService> AddProductAsync(Product product);
    Task<List<Product>> GetProductsAsync();
}

