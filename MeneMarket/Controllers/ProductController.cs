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
            IProductOrchestrationService productOrchestrationService)
        {
            this.productOrchestrationService = productOrchestrationService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<Product>> PostProductAsync(Product product) =>
            await this.productOrchestrationService.AddProductAsync(product);

        [HttpGet]
        public IQueryable<Product> GelAllProducts() =>
            this.productOrchestrationService.RetrieveAllProducts();

        [HttpGet("ById")]
        public async ValueTask<ActionResult<Product>> GetProductByIdAsync(Guid id) =>
            await this.productOrchestrationService.RetrieveProductByIdAsync(id);

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<Product>> PutProductAsync(Product product) =>
            await this.productOrchestrationService.ModifyProductAsync(product);

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<Product>> DeleteProductAsync(Guid id) =>
            await this.productOrchestrationService.RemoveProductAsync(id);
    }
}