using MeneMarket.Models.Foundations.ProductRequests;

namespace MeneMarket.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<ProductRequest> InsertProductRequestAsync(ProductRequest productRequest);
        IQueryable<ProductRequest> SelectAllProductRequests();
        ValueTask<ProductRequest> SelectProductRequestByIdAsync(Guid productRequestId);
        ValueTask<ProductRequest> UpdateProductRequestAsync(ProductRequest productRequest);
        ValueTask<ProductRequest> DeleteProductRequestAsync(ProductRequest productRequest);
    }
}
