using MeneMarket.Models.Foundations.Products;

namespace MeneMarket.Services.Processings.Products
{
    public interface IProductProcessingService
    {
        ValueTask<Product> AddProductAsync(Product product);
        IQueryable<Product> RetrieveAllProducts();
        ValueTask<Product> RetrieveProductByIdAsync(Guid id);
        ValueTask<Product> ModifyProductAsync(Product product);
        ValueTask<Product> RemoveProductByIdAsync(Guid id);
    }
}