using MeneMarket.Models.Foundations.Products;
using MeneMarket.Services.Orchestrations.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace MeneMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : RESTFulController
    {
        private readonly IProductOrchestrationService productOrchestrationService;

        public ProductController(
            IProductOrchestrationService productOrchestrationService) =>
                this.productOrchestrationService = productOrchestrationService;

        [HttpPost]
        public async ValueTask<ActionResult<Product>> PostProductAsync(Product product) =>
            await this.productOrchestrationService.AddProductAsync(product);

        [HttpGet]
        [Authorize]
        public async  Task<List<Product>> GelAllProducts() =>
                 await this.productOrchestrationService.RetrieveAllProducts();

        [HttpGet("ById")]
        public async ValueTask<ActionResult<Product>> GetProductByIdAsync(Guid id) =>
            await this.productOrchestrationService.RetrieveProductByIdAsync(id);

        [HttpPut]
        public async ValueTask<ActionResult<Product>> PutProduct(Product product) =>
            await this.productOrchestrationService.ModifyProductAsync(product);
        
        [HttpDelete]
        public async ValueTask<ActionResult<Product>> DeleteProduct(Guid id) =>
            await this.productOrchestrationService.RemoveProductAsync(id);
    }
}