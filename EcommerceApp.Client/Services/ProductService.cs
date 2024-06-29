using EcommerceApp.Client.Models;

namespace EcommerceApp.Client.Services;
public class ProductService : IProductService
{
    private readonly HttpClient httpClient;

    public ProductService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    public Task<List<Category>> GetCategoriesAsync()
    {
        throw new NotImplementedException();
    }
}

