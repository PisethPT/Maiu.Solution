using Ecommerce.Library.Models;
using Ecommerce.Library.Response;
using Ecommerce.WebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.WebApi.Services
{
    public class ProductService(AppDbContext appDbContext) : IProductService
    {
        private readonly AppDbContext appDbContext = appDbContext;

        public async Task<ServiceResponse> AddProductAsync(Product product)
        {
            if (product is null) return new ServiceResponse() { IsSuccess = false, Message = "Bad Request" };

            var check = await appDbContext.Products.Where(p => p.Name.ToLower().Equals(product.Name.ToLower())).FirstOrDefaultAsync();
            if(check is null)
            {
                appDbContext.Products.Add(product);
                await appDbContext.SaveChangesAsync();
                return new ServiceResponse() { IsSuccess = true, Message = "Product added." };
            }
            return new ServiceResponse() { IsSuccess = false, Message = "Product already added." };
        }

        public async Task<ServiceResponse> DeleteProductAsync(int productId)
        {
            var product = await appDbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);
            if (product is null) return new ServiceResponse() { IsSuccess = false, Message = "Product not found." };
            appDbContext.Products.Remove(product);
            await appDbContext.SaveChangesAsync();
            return new ServiceResponse() { IsSuccess = true, Message = "Product deleted" };
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var product = await appDbContext.Products.FirstOrDefaultAsync(p => p.Id.Equals(productId));
            return product!;
        }

        public async Task<List<Product>> GetProductsAsync() => await appDbContext.Products.ToListAsync(); // lamda expression

        public async Task<ServiceResponse> UpdateProductAsync(Product product)
        {
            var result = await appDbContext.Products.Include(c =>c.Category).FirstOrDefaultAsync(p => p.Id.Equals(product.Id));
            if(result is null) return new ServiceResponse() { IsSuccess = false, Message = "Product not found." };
            // appDbContext.Update(result);

            result.Name = product.Name;
            result.Description = product.Description;
            result.CategoryId = product.CategoryId;
            result.Price = product.Price;
            result.Quantity = product.Quantity;
            result.Image = product.Image;

            return new ServiceResponse() { IsSuccess = true, Message = "Product updated" };
        }
    }
}
