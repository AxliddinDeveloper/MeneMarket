using MeneMarket.Models.Foundations.ProductRequests;

namespace MeneMarket.Services.Foundations.ProductRequests
{
    public interface IProductRequestService
    {
        ValueTask<ProductRequest> AddProductRequestAsync(ProductRequest productRequest);
        IQueryable<ProductRequest> RetrieveAllProductRequests();
        ValueTask<ProductRequest> RetrieveProductRequestByIdAsync(Guid id);
        ValueTask<ProductRequest> ModifyProductRequestAsync(ProductRequest productRequest);
        ValueTask<ProductRequest> RemoveProductRequestAsync(ProductRequest productRequest);
    }
}