using MeneMarket.Brokers.Storages;
using MeneMarket.Models.Foundations.ProductTypes;


namespace MeneMarket.Services.Foundations.ProductTypes
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IStorageBroker storageBroker;

        public ProductTypeService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<ProductType> AddProductTypeAsync(ProductType ProductType)
        {
            ProductType.ProductTypeId = Guid.NewGuid();
            return await this.storageBroker.InsertProductTypeAsync(ProductType);
        }

        public IQueryable<ProductType> RetrieveAllProductTypes() =>
            this.storageBroker.SelectAllProductTypes();

        public async ValueTask<ProductType> RetrieveProductTypeByIdAsync(Guid id) =>
            await this.storageBroker.SelectProductTypeByIdAsync(id);

        public async ValueTask<ProductType> ModifyProductTypeAsync(ProductType PoductAttribute) =>
            await this.storageBroker.UpdateProductTypeAsync(PoductAttribute);

        public async ValueTask<ProductType> RemoveProductTypeAsync(Guid id)
        {
            ProductType mayBeProductType =
                await this.storageBroker.SelectProductTypeByIdAsync(id);

            return await this.storageBroker.DeleteProductTypeAsync(mayBeProductType);
        }
    }
}
