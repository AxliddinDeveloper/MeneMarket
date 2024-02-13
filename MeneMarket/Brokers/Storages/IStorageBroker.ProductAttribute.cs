using MeneMarket.Models.Foundations.ProductAttributes;
using MeneMarket.Models.Foundations.Products;

namespace MeneMarket.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<ProductAttribute> InsertProductAttributeAsync(ProductAttribute productAttribute);
        IQueryable<ProductAttribute> SelectAllProductAttributes();
        ValueTask<ProductAttribute> SelectProductAttributeByIdAsync(Guid productAttributeId);
        ValueTask<ProductAttribute> UpdateProductAttributeAsync(ProductAttribute productAttribute);
        ValueTask<ProductAttribute> DeleteProductAttributeAsync(ProductAttribute productAttribute);
    }
}
