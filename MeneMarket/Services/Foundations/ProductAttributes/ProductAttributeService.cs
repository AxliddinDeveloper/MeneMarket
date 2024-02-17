using MeneMarket.Brokers.Storages;
using MeneMarket.Models.Foundations.ProductAttributes;
using RESTFulSense.Exceptions;

namespace MeneMarket.Services.Foundations.ProductAttributes
{
    public class ProductAttributeService : IProductAttributeService
    {
        private readonly IStorageBroker storageBroker;

        public ProductAttributeService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<ProductAttribute> AddProductAttributeAsync(ProductAttribute productAttribute) =>
            await this.storageBroker.InsertProductAttributeAsync(productAttribute);

        public IQueryable<ProductAttribute> RetrieveAllProductAttributes() =>
            this.storageBroker.SelectAllProductAttributes();

        public async ValueTask<ProductAttribute> RetrieveProductAttributeByIdAsync(Guid id) =>
            await this.storageBroker.SelectProductAttributeByIdAsync(id);

        public async ValueTask<ProductAttribute> ModifyProductAttributeAsync(ProductAttribute PoductAttribute) =>
            await this.storageBroker.UpdateProductAttributeAsync(PoductAttribute);

        public async ValueTask<ProductAttribute> RemoveProductAttributeAsync(Guid id)
        {
            ProductAttribute mayBeProductAttribute =
                await this.storageBroker.SelectProductAttributeByIdAsync(id);

             return await this.storageBroker.DeleteProductAttributeAsync(mayBeProductAttribute);
        }
    }
}
