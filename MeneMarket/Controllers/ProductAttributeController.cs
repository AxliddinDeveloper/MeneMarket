using MeneMarket.Models.Foundations.ProductAttributes;
using MeneMarket.Services.Foundations.ProductAttributes;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace MeneMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductAttributeController : RESTFulController
    {
        private readonly IProductAttributeService productAttributeService;

        public ProductAttributeController(
            IProductAttributeService productAttributeService) =>
                this.productAttributeService = productAttributeService;

        [HttpPost]
        public async ValueTask<ActionResult<ProductAttribute>> PostProductAttributeAsync(ProductAttribute productAttribute) =>
            await this.productAttributeService.AddProductAttributeAsync(productAttribute);

        [HttpGet]
        public ActionResult<IQueryable<ProductAttribute>> GelAllProductAttributes()
        {
            IQueryable<ProductAttribute> allProductAttributes =
                this.productAttributeService.RetrieveAllProductAttributes();

            return Ok(allProductAttributes);
        }

        [HttpGet("ById")]
        public async ValueTask<ActionResult<ProductAttribute>> GetProductAttributeByIdAsync(Guid id) =>
            await this.productAttributeService.RetrieveProductAttributeByIdAsync(id);

        [HttpPut]
        public async ValueTask<ActionResult<ProductAttribute>> PutProductAttributeAsync(ProductAttribute productAttribute) =>
            await this.productAttributeService.ModifyProductAttributeAsync(productAttribute);

        [HttpDelete]
        public async ValueTask<ActionResult<ProductAttribute>> DeleteProductAttributeAsync(ProductAttribute productAttribute) =>
            await this.productAttributeService.RemoveProductAttributeAsync(productAttribute);
    }
}
