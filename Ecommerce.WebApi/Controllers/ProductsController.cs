using Ecommerce.Library.Models;
using Ecommerce.Library.Response;
using Ecommerce.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService, ICategoryService categoryService) : ControllerBase
    {
        private readonly IProductService productService = productService;
        private readonly ICategoryService categoryService = categoryService;

        [HttpGet] // view 
        // public async Task<ActionResult<List<Product>>> GetProductsAsync() => await productService.GetProductsAsync();
        public async Task<ActionResult<List<Product>>> GetProductsAsync() => Ok(await productService.GetProductsAsync());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProductByIdAsync(int id)
        {
            var product = await productService.GetProductByIdAsync(id);
            if (product is null)
                return NotFound("Product not found");
            return Ok(product);
        }

        [HttpDelete("{id:int}")] // delete
        public async Task<ActionResult<ServiceResponse>> DeleteProductAsync(int id)
        {
            var product = await productService.GetProductByIdAsync(id);
            if (product is null)
                return NotFound("Product not found");

            var response = await productService.DeleteProductAsync(product.Id);
            if (!response.IsSuccess)
                return NotFound(response.Message);
            return Ok(response.Message);
        }

        [HttpPut] // update
        public async Task<ActionResult<ServiceResponse>> UpdateProductAsync(Product product)
        {
            var result = await productService.GetProductByIdAsync(product.Id);
            if (result is null)
                return NotFound("Product not found");
            var response = await productService.UpdateProductAsync(product);
            if (!response.IsSuccess)
                return NotFound(response.Message);
            return Ok(response.Message);
        }

        [HttpPost] // insert
        public async Task<ActionResult<ServiceResponse>> AddProductAsync(Product product)
        {
            if (product is null)
                return BadRequest("Bad request");
            var result = await productService.AddProductAsync(product);
            if (result.IsSuccess)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }



        [HttpGet("categories")]
        public async Task<ActionResult<List<Category>>> GetAllCategoriesAsync() => Ok(await categoryService.GetAllCategoriesAsync());
    }
}
