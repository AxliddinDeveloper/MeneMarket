﻿using MeneMarket.Models.Foundations.ProductAttributes;
using MeneMarket.Services.Foundations.ProductAttributes;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<ProductAttribute>> PostProductAttributeAsync(ProductAttribute productAttribute) =>
            await this.productAttributeService.AddProductAttributeAsync(productAttribute);

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IQueryable<ProductAttribute>> GelAllProductAttributes()
        {
            IQueryable<ProductAttribute> allProductAttributes =
                this.productAttributeService.RetrieveAllProductAttributes();

            return Ok(allProductAttributes);
        }

        [HttpGet("ById")]
        [Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<ProductAttribute>> GetProductAttributeByIdAsync(Guid id) =>
            await this.productAttributeService.RetrieveProductAttributeByIdAsync(id);

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<ProductAttribute>> PutProductAttributeAsync(ProductAttribute productAttribute) =>
            await this.productAttributeService.ModifyProductAttributeAsync(productAttribute);

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<ProductAttribute>> DeleteProductAttributeAsync(Guid id) =>
            await this.productAttributeService.RemoveProductAttributeAsync(id);
    }
}
