using MeneMarket.Models.Foundations.ProductAttributes;
using MeneMarket.Models.Foundations.Products;
using MeneMarket.Services.Foundations.ProductAttributes;
using MeneMarket.Services.Processings.Files;
using MeneMarket.Services.Processings.Products;

namespace MeneMarket.Services.Orchestrations.Products
{
    public class ProductOrchestrationService : IProductOrchestrationService
    {
        private readonly IProductProcessingService productProcessingService;
        private readonly IProductAttributeService productAttributeService;
        private readonly IFileProcessingService fileProcessingService;

        public ProductOrchestrationService(
            IProductProcessingService productProcessingService,
            IFileProcessingService fileProcessingService,
            IProductAttributeService productAttributeService)
        {
            this.productProcessingService = productProcessingService;
            this.productAttributeService = productAttributeService;
            this.fileProcessingService = fileProcessingService;
        }

        public async ValueTask<Product> AddProductAsync(Product product,
            List<IFormFile> images)
        {
            product.ProductId = Guid.NewGuid();

            var storedProduct =
                 await this.productProcessingService.AddProductAsync(product);

            if (images != null)
            {
                foreach (var image in images)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        image.CopyTo(memoryStream);
                        memoryStream.Position = 0;

                        string filePath =
                            await this.fileProcessingService.UploadFileAsync(
                                memoryStream, image.FileName);

                        if (storedProduct.Images == null)
                            storedProduct.Images = new List<string>();

                        storedProduct.Images.Add(filePath);
                    }
                }
                await this.productProcessingService.ModifyProductAsync(storedProduct);
            }

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

                return await this.productProcessingService.RetrieveProductByIdAsync(storedProduct.ProductId);
            }
            else
                throw new InvalidDataException("Product is invalid");
        }

        public IQueryable<Product> RetrieveAllProducts(Guid userId)
        {


            return this.productProcessingService.RetrieveAllProducts();
        }

        public async ValueTask<Product> RetrieveProductByIdAsync(Guid id) =>
            await this.productProcessingService.RetrieveProductByIdAsync(id);

        public async ValueTask<Product> ModifyProductAsync(
            Product product, 
            List<IFormFile> images, 
            List<string> imageFilePaths)
        {
            if (images != null)
            {
                foreach (var image in images)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        image.CopyTo(memoryStream);
                        memoryStream.Position = 0;

                        await this.fileProcessingService.UploadFileAsync(memoryStream, image.FileName);
                    }
                }
            }

            if (imageFilePaths != null)
            {
                foreach (var imageFile in imageFilePaths)
                {
                    string imageName = imageFile.Replace(@"imageFiles\\", "");
                    this.fileProcessingService.DeleteImageFile(imageName);
                }
            }

            if (product.ProductAttributes != null)
            {
                foreach (var attribute in product.ProductAttributes)
                    await this.productAttributeService.ModifyProductAttributeAsync(attribute);
            }

            return await this.productProcessingService.ModifyProductAsync(product);
        }

        public async ValueTask<Product> RemoveProductAsync(Guid id)
        {
            var product =
                await this.productProcessingService.RetrieveProductByIdAsync(id);

            foreach (var imageFilePath in product.Images)
            {
                string imageName = imageFilePath.Replace(@"imageFiles\\", "");
                fileProcessingService.DeleteImageFile(imageName);
            }

            return await this.productProcessingService.RemoveProductByIdAsync(id);
        }
    }
}