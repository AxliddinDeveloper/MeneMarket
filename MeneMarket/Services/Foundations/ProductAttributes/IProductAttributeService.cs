using MeneMarket.Models.Foundations.ProductAttributes;
using MeneMarket.Models.Foundations.Products;

namespace MeneMarket.Services.Foundations.ProductAttributes
{
    public interface IProductAttributeService
    {
        ValueTask<ProductAttribute> AddProductAttributeAsync(ProductAttribute productAttribute);
        IQueryable<ProductAttribute> RetrieveAllProductAttributes();
        ValueTask<ProductAttribute> RetrieveProductAttributeByIdAsync(Guid id);
        ValueTask<ProductAttribute> ModifyProductAttributeAsync(ProductAttribute productAttribute);
        ValueTask<ProductAttribute> RemoveProductAttributeAsync(Guid id);
    }
}
