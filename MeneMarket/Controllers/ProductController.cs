using System.Security.Claims;
using MeneMarket.Models.Foundations.Products;
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
        private readonly IHttpContextAccessor httpContextAccessor;
        public ProductController(
            IProductOrchestrationService productOrchestrationService, 
            IHttpContextAccessor httpContextAccessor)
        {
            this.productOrchestrationService = productOrchestrationService;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<Product>> PostProductAsync([FromForm]ProductWithImages request)
        {
            Product product = request.Product;
            product.ProductAttributes = request.ProductAttributes;
            List<IFormFile> images = request.Images;

            return await this.productOrchestrationService.AddProductAsync(product, images);
        }

        [HttpGet]
        [Route("GetAll")]
        public IQueryable<Product> GetAllProducts()
        {
            var userId = 
                httpContextAccessor.HttpContext.User.FindFirstValue("UserId");

            return productOrchestrationService.RetrieveAllProducts();
        }

        [HttpGet("ById")]
        public async ValueTask<ActionResult<Product>> GetProductByIdAsync(Guid id) =>
            await this.productOrchestrationService.RetrieveProductByIdAsync(id);

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<Product>> PutProductAsync(ProductWithImages productWithImages)
        {
            var product = productWithImages.Product;
            List<IFormFile> images = productWithImages.Images;
            List<string> imageFilePaths = productWithImages.ImageFilePaths;

            return await this.productOrchestrationService.ModifyProductAsync(product, images, imageFilePaths);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<Product>> DeleteProductAsync(Guid id) =>
            await this.productOrchestrationService.RemoveProductAsync(id);
    }
}