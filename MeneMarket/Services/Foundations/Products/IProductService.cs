using MeneMarket.Models.Foundations.Products;

namespace MeneMarket.Services.Foundations.Products
{
    public interface IProductService
    {
        ValueTask<Product> AddProductAsync(Product product);
        Task<List<Product>> RetrieveAllProducts();
        ValueTask<Product> RetrieveProductByIdAsync(Guid id);
        ValueTask<Product> ModifyProductAsync(Product product);
        ValueTask<Product> RemoveProductAsync(Guid id);
    }
}
