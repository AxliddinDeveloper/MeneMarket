using MeneMarket.Models.Foundations.ProductRequests;
using Microsoft.EntityFrameworkCore;

namespace MeneMarket.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<ProductRequest> ProductRequests { get; set; }

        public async ValueTask<ProductRequest> InsertProductRequestAsync(ProductRequest productRequest) =>
            await InsertAsync(productRequest);

        public IQueryable<ProductRequest> SelectAllProductRequests() =>
            SelectAll<ProductRequest>();

        public async ValueTask<ProductRequest> SelectProductRequestByIdAsync(Guid productRequestId) =>
            await SelectAsync<ProductRequest>(productRequestId);

        public async ValueTask<ProductRequest> UpdateProductRequestAsync(ProductRequest productRequest) =>
            await UpdateAsync(productRequest);

        public async ValueTask<ProductRequest> DeleteProductRequestAsync(ProductRequest productRequest) =>
            await DeleteAsync(productRequest);
    }
}
