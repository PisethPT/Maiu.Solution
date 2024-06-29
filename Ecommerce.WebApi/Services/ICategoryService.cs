using Ecommerce.Library.Models;

namespace Ecommerce.WebApi.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategoriesAsync();
    }
}
