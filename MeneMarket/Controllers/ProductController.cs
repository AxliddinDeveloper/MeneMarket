using MeneMarket.Models.Foundations.Products;
using MeneMarket.Services.Foundations.Products;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace MeneMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : RESTFulController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<Product>> PostProductAsync(Product product) =>
            await this.productService.AddProductAsync(product);

        [HttpGet]
        public async  Task<List<Product>> GelAllProducts() =>
                 await this.productService.RetrieveAllProducts();

        [HttpGet("ById")]
        public async ValueTask<ActionResult<Product>> GetProductByIdAsync(Guid id) =>
            await this.productService.RetrieveProductByIdAsync(id);

        [HttpPut]
        public async ValueTask<ActionResult<Product>> PutProduct(Product product) =>
            await this.productService.ModifyProductAsync(product);
        
        [HttpDelete]
        public async ValueTask<ActionResult<Product>> DeleteProduct(Guid id) =>
            await this.productService.RemoveProductAsync(id);
    }
}
