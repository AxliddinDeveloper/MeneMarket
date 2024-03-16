using MeneMarket.Models.Foundations.ProductAttributes;
using MeneMarket.Models.Foundations.Products;
using MeneMarket.Services.Foundations.ProductAttributes;
using MeneMarket.Services.Orchestrations.Images;
using MeneMarket.Services.Processings.Products;

namespace MeneMarket.Services.Orchestrations.Products
{
    public class ProductOrchestrationService : IProductOrchestrationService
    {
        private readonly IProductProcessingService productProcessingService;
        private readonly IProductAttributeService productAttributeService;
        private readonly IImageOrchestrationService imageOrchestrationService;

        public ProductOrchestrationService(
            IProductProcessingService productProcessingService, 
            IProductAttributeService productAttributeService,
            IImageOrchestrationService imageOrchestrationService)
        {
            this.productProcessingService = productProcessingService;
            this.productAttributeService = productAttributeService;
            this.imageOrchestrationService = imageOrchestrationService;
        }

        public async ValueTask<Product> AddProductAsync(Product product)
        {
            product.ProductId = Guid.NewGuid();

            var storedProduct =
                 await this.productProcessingService.AddProductAsync(product);

            if (product.ProductAttributes != null)
            {
                foreach (var attribute in storedProduct.ProductAttributes)
                {
                    var productAttribute = new ProductAttribute
                    {
                        Product = storedProduct,
                        Count = attribute.Count,
                        Size = attribute.Size,
                        Belong = attribute.Belong,
                        Color = attribute.Color,
                        ProductId = storedProduct.ProductId
                    };

                    await this.productAttributeService.AddProductAttributeAsync(productAttribute);
                }

                product.ProductAttributes = null;

                return await this.productProcessingService.RetrieveProductByIdAsync(storedProduct.ProductId);
            }
            else
                throw new InvalidDataException("Product is invalid");
        }

        public IQueryable<Product> RetrieveAllProducts() =>
             this.productProcessingService.RetrieveAllProducts();

        public async ValueTask<Product> RetrieveProductByIdAsync(Guid id) =>
            await this.productProcessingService.RetrieveProductByIdAsync(id);

        public async ValueTask<Product> ModifyProductAsync(Product product)
        {
            foreach (var attribute in product.ProductAttributes)
            {
                await this.productAttributeService.ModifyProductAttributeAsync(attribute);
            }

            return await this.ModifyProductAsync(product);
        }

        public async ValueTask<Product> RemoveProductAsync(Guid id)
        {
            var product = 
                await this.productProcessingService.RetrieveProductByIdAsync(id);

            foreach (var image in product.ImageMetadatas)
            {
                imageOrchestrationService.RemoveImageFileByIdAsync(image.Id);
            }

            return await this.productProcessingService.RemoveProductByIdAsync(id);
        }
    }
}