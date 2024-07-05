using EcommerceApp.Client.Models;
using System.Net.Http.Json;

namespace EcommerceApp.Client.Services;
public class ProductService(HttpClient httpClient) : IProductService
{
    private readonly HttpClient httpClient = httpClient;

    public async Task<ResponseService> AddProductAsync(Product product)
    {
        var request = await httpClient.PostAsJsonAsync("https://localhost:7071/api/Products", product);
        var response = await request.Content.ReadFromJsonAsync<ResponseService>();
        return response;
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        var request = await httpClient.GetAsync("https://localhost:7071/api/Products/categories");
        var categories = await request.Content.ReadFromJsonAsync<List<Category>>();
        return categories ?? [];
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        var request = await httpClient.GetAsync("https://localhost:7071/api/Products");
        var products = await request.Content.ReadFromJsonAsync<List<Product>>();
        return products ?? [];
    }
}

