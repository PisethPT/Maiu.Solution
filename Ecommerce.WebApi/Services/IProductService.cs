using Ecommerce.Library.Models;
using Ecommerce.Library.Response;

namespace Ecommerce.WebApi.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync(); // return list of products
        Task<ServiceResponse> AddProductAsync(Product product); // return Message and IsSuccess
        Task<ServiceResponse> UpdateProductAsync(Product product); //  return Message and IsSuccess
        Task<ServiceResponse> DeleteProductAsync(int productId); //  return Message and IsSuccess
        Task<Product> GetProductByIdAsync(int productId); //  return product

    }
}
