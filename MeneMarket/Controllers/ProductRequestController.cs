using MeneMarket.Models.Foundations.ProductRequests;
using MeneMarket.Services.Orchestrations.ProductRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace MeneMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductRequestController : RESTFulController
    {
        private readonly IProductRequestOrchestrationService productRequestOrchestrationService;

        public ProductRequestController(
            IProductRequestOrchestrationService productRequestOrchestrationService)
        {
            this.productRequestOrchestrationService = productRequestOrchestrationService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<ProductRequest>> PostProductRequestAsync(ProductRequest productRequest)
        {
            var httpContext = HttpContext;
            string ipAddress = httpContext.Connection.RemoteIpAddress?.ToString();
            productRequest.IpAddress = ipAddress;

            return await this.productRequestOrchestrationService.AddProductRequestAsync(productRequest);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IQueryable<ProductRequest>> GelAllProductRequests()
        {
            IQueryable<ProductRequest> allProductRequests =
                this.productRequestOrchestrationService.RetrieveAllProductRequests();

            return Ok(allProductRequests);
        }

        [HttpGet("ById")]
        [Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<ProductRequest>> GetProductRequestByIdAsync(Guid id) =>
            await this.productRequestOrchestrationService.RetrieveProductRequestByIdAsync(id);

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<ProductRequest>> PutProductRequestAsync(ProductRequest productRequest) =>
            await this.productRequestOrchestrationService.ModifyProductRequestAsync(productRequest);

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<ProductRequest>> DeleteProductRequestAsync(Guid id) =>
            await this.productRequestOrchestrationService.RemoveProductRequestByIdAsync(id);
    }
}