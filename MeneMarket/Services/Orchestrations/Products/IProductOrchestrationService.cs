using MeneMarket.Models.Foundations.Products;
using MeneMarket.Models.Orchestrations.CombinedProducts;

namespace MeneMarket.Services.Orchestrations.Products
{
    public interface IProductOrchestrationService
    {
        ValueTask<Product> AddProductAsync(Product product, List<string> bytes);
        CombinedProducts RetrieveAllProducts(int userRole);
        ValueTask<Product> RetrieveProductByIdAsync(Guid id);
        ValueTask<Product> ModifyProductAsync(Product product, List<string> bytes64String);
        ValueTask<Product> RemoveProductAsync(Guid id);
    }
}