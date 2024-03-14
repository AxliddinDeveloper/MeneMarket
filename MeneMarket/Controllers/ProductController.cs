using MeneMarket.Models.Foundations.Products;
using MeneMarket.Services.Processings.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace MeneMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : RESTFulController
    {
        private readonly IProductProcessingService productProcessingService;

        public ProductController(IProductProcessingService productProcessingService)
        {
            this.productProcessingService = productProcessingService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<Product>> PostProductAsync(Product product) =>
            await this.productProcessingService.AddProductAsync(product);

        [HttpGet]
        public async  Task<List<Product>> GelAllProductsAsync() =>
            await this.productProcessingService.RetrieveAllProductsAsync();

        [HttpGet("ById")]
        public async ValueTask<ActionResult<Product>> GetProductByIdAsync(Guid id) =>
            await this.productProcessingService.RetrieveProductByIdAsync(id);

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<Product>> PutProductAsync(Product product) =>
            await this.productProcessingService.ModifyProductAsync(product);
        
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<Product>> DeleteProductAsync(Guid id) =>
            await this.productProcessingService.RemoveProductByIdAsync(id);
    }
}