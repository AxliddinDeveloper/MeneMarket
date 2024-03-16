using MeneMarket.Models.Foundations.Products;

namespace MeneMarket.Services.Orchestrations.Products
{
    public interface IProductOrchestrationService
    {
        ValueTask<Product> AddProductAsync(Product product);
        IQueryable<Product> RetrieveAllProducts();
        ValueTask<Product> RetrieveProductByIdAsync(Guid id);
        ValueTask<Product> ModifyProductAsync(Product product);
        ValueTask<Product> RemoveProductAsync(Guid id);
    }
}
