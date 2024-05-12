using MeneMarket.Models.Foundations.ProductTypes;

namespace MeneMarket.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<ProductType> InsertProductTypeAsync(ProductType ProductType);
        IQueryable<ProductType> SelectAllProductTypes();
        ValueTask<ProductType> SelectProductTypeByIdAsync(Guid ProductType);
        ValueTask<ProductType> UpdateProductTypeAsync(ProductType pProductTyperoductAttribute);
        ValueTask<ProductType> DeleteProductTypeAsync(ProductType ProductType);
    }
}