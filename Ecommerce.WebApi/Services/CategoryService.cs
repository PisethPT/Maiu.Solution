using Ecommerce.Library.Models;
using Ecommerce.WebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.WebApi.Services
{
    public class CategoryService(AppDbContext appDbContext) : ICategoryService
    {
        private readonly AppDbContext appDbContext = appDbContext;

        public async Task<List<Category>> GetAllCategoriesAsync() => await appDbContext.Categories.ToListAsync();
    }
}
