using MeneMarket.Models.Foundations.ProductRequests;

namespace MeneMarket.Services.Orchestrations.ProductRequests
{
    public interface IProductRequestOrchestrationService
    {
        ValueTask<ProductRequest> AddProductRequestAsync(ProductRequest productRequest);
        IQueryable<ProductRequest> RetrieveAllProductRequests();
        ValueTask<ProductRequest> RetrieveProductRequestByIdAsync(Guid id);
        ValueTask<ProductRequest> ModifyProductRequestAsync(ProductRequest productRequest);
        ValueTask<ProductRequest> RemoveProductRequestByIdAsync(Guid id);
    }
}