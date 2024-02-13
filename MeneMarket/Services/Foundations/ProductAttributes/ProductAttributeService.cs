using MeneMarket.Brokers.Storages;
using MeneMarket.Models.Foundations.ProductAttributes;

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

        public async ValueTask<ProductAttribute> ModifyProductAttributeAsync(ProductAttribute PoductAttribute) =>
            await this.storageBroker.UpdateProductAttributeAsync(PoductAttribute);

        public async ValueTask<ProductAttribute> RemoveProductAttributeAsync(Guid id)
        {
            ProductAttribute productAttribute = 
                await this.RetrieveProductAttributeByIdAsync(id);

            return await this.storageBroker.DeleteProductAttributeAsync(productAttribute);
        }

        public IQueryable<ProductAttribute> RetrieveAllProductAttributes() =>
            this.RetrieveAllProductAttributes();

        public async ValueTask<ProductAttribute> RetrieveProductAttributeByIdAsync(Guid id) =>
            await this.RetrieveProductAttributeByIdAsync(id);
    }
}
