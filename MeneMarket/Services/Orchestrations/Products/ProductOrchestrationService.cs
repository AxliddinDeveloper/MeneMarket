using MeneMarket.Models.Foundations.Products;
using MeneMarket.Services.Processings.Products;

namespace MeneMarket.Services.Orchestrations.Products
{
    public class ProductOrchestrationService : IProductOrchestrationService
    {
        private readonly IProductProcessingService productProcessingService;

        public ProductOrchestrationService(
            IProductProcessingService productProcessingService)
        {
            this.productProcessingService = productProcessingService;
        }

        public async ValueTask<Product> AddProductAsync(Product product) =>
             await this.productProcessingService.AddProductAsync(product);

        public async Task<List<Product>> RetrieveAllProducts() =>
            await this.productProcessingService.RetrieveAllProductsAsync();

        public async ValueTask<Product> RetrieveProductByIdAsync(Guid id) =>
            await this.productProcessingService.RetrieveProductByIdAsync(id);

        public async ValueTask<Product> ModifyProductAsync(Product product) => 
            await this.productProcessingService.ModifyProductAsync(product);

        public async ValueTask<Product> RemoveProductAsync(Guid id) =>
            await this.productProcessingService.RemoveProductByIdAsync(id);
    }
}