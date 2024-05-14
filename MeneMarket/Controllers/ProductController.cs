using MeneMarket.Models.Foundations.Products;
using MeneMarket.Models.Orchestrations.CombinedProducts;
using MeneMarket.Models.Orchestrations.ProductWithImages;
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
        public async ValueTask<ActionResult<Product>> PostProductAsync(ProductWithImages productWithImages) =>
            await this.productOrchestrationService.AddProductAsync(productWithImages.Product, productWithImages.bytes);

        [HttpGet]
        public CombinedProducts GetAllProducts()
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == "Role");
            int userRoleInInteger;

            if (userRole != null)
                userRoleInInteger = Int32.Parse(userRole.Value);
            else 
                userRoleInInteger = 0;

            return productOrchestrationService.RetrieveAllProducts(userRoleInInteger);
        }

        [HttpGet("ById")]
        public async ValueTask<ActionResult<Product>> GetProductByIdAsync(Guid id) =>
            await this.productOrchestrationService.RetrieveProductByIdAsync(id);

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<Product>> PutProductAsync(ProductWithImages productWithImages) =>
            await this.productOrchestrationService.ModifyProductAsync(
                productWithImages.Product,
                productWithImages.bytes);

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<Product>> DeleteProductAsync(Guid id) =>
            await this.productOrchestrationService.RemoveProductAsync(id);
    }
}