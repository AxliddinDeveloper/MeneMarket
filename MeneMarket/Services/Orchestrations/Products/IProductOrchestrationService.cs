using MeneMarket.Models.Foundations.Products;

namespace MeneMarket.Services.Orchestrations.Products
{
    public interface IProductOrchestrationService
    {
        ValueTask<Product> AddProductAsync(Product product,
            List<string> bytes);

        IQueryable<Product> RetrieveAllProducts();
        ValueTask<Product> RetrieveProductByIdAsync(Guid id);
        ValueTask<Product> ModifyProductAsync(Product product, 
            List<string> bytes64String);

        ValueTask<Product> RemoveProductAsync(Guid id);
    }
}
