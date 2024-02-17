using MeneMarket.Brokers.Storages;
using MeneMarket.Models.Foundations.ProductRequests;

namespace MeneMarket.Services.Foundations.ProductRequests
{
    public class ProductRequestService : IProductRequestService
    {
        private readonly IStorageBroker storageBroker;

        public ProductRequestService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<ProductRequest> AddProductRequestAsync(ProductRequest productRequest) =>
            await this.storageBroker.InsertProductRequestAsync(productRequest);

        public async ValueTask<ProductRequest> ModifyProductRequestAsync(ProductRequest productRequest) =>
            await this.storageBroker.UpdateProductRequestAsync(productRequest);

        public async ValueTask<ProductRequest> RemoveProductRequestAsync(Guid id)
        {
            ProductRequest mayBeProductRequest = 
                await this.storageBroker.SelectProductRequestByIdAsync(id);

            return await this.storageBroker.DeleteProductRequestAsync(mayBeProductRequest);
        }

        public IQueryable<ProductRequest> RetrieveAllProductRequests() =>
            this.storageBroker.SelectAllProductRequests();

        public async ValueTask<ProductRequest> RetrieveProductRequestByIdAsync(Guid id) =>
            await this.storageBroker.SelectProductRequestByIdAsync(id);
    }
}
