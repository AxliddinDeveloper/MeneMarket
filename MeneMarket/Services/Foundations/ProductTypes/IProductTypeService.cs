using MeneMarket.Models.Foundations.ProductTypes;

namespace MeneMarket.Services.Foundations.ProductTypes
{
    public interface IProductTypeService
    {
        ValueTask<ProductType> AddProductTypeAsync(ProductType ProductType);
        IQueryable<ProductType> RetrieveAllProductTypes();
        ValueTask<ProductType> RetrieveProductTypeByIdAsync(Guid id);
        ValueTask<ProductType> ModifyProductTypeAsync(ProductType ProductType);
        ValueTask<ProductType> RemoveProductTypeAsync(Guid id);
    }
}