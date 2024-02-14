using MeneMarket.Models.Foundations.Products;
using MeneMarket.Services.Foundations.Products;
using MeneMarket.Services.Orchestrations.Products;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace MeneMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : RESTFulController
    {
        private readonly IProductService productService;
        private readonly IProductOrchestrationService productOrchestrationService;

        public ProductController(
            IProductService productService, 
            IProductOrchestrationService productOrchestrationService)
        {
            this.productService = productService;
            this.productOrchestrationService = productOrchestrationService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<Product>> PostProductAsync(Product product) =>
            await this.productOrchestrationService.AddProductAsync(product);

        [HttpGet]
        public async  Task<List<Product>> GelAllProducts() =>
                 await this.productService.RetrieveAllProductsAsync();

        [HttpGet("ById")]
        public async ValueTask<ActionResult<Product>> GetProductByIdAsync(Guid id) =>
            await this.productService.RetrieveProductByIdAsync(id);

        [HttpPut]
        public async ValueTask<ActionResult<Product>> PutProduct(Product product) =>
            await this.productService.ModifyProductAsync(product);
        
        [HttpDelete]
        public async ValueTask<ActionResult<Product>> DeleteProduct(Product product) =>
            await this.productService.RemoveProductAsync(product);
    }
}