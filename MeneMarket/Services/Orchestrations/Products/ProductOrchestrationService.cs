using MeneMarket.Models.Foundations.ProductAttributes;
using MeneMarket.Models.Foundations.Products;
using MeneMarket.Models.Orchestrations.UserWithImages;
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
            List<string> bytes64String)
        {
            product.ProductId = Guid.NewGuid();

            if (product.ProductAttributes == null)
                throw new ArgumentNullException("Product Attribute is null");

            var storedProduct =
               await this.productProcessingService.AddProductAsync(product);

            if (bytes64String != null)
            {
                foreach (var byte64String in bytes64String)
                {
                    string fileName = Guid.NewGuid().ToString() + ".jpg";
                    byte[] bytes = Convert.FromBase64String(byte64String);
                    var memoryStream = ConvertBytesToMemoryStream(bytes);
                    string filePath =
                            await this.fileProcessingService.UploadFileAsync(
                                memoryStream, fileName);

                    if (storedProduct.Images == null)
                         storedProduct.Images = new List<string>();

                    storedProduct.Images.Add(filePath);
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

        public IQueryable<Product> RetrieveAllProducts() =>
            this.productProcessingService.RetrieveAllProducts();

        public async ValueTask<Product> RetrieveProductByIdAsync(Guid id) =>
            await this.productProcessingService.RetrieveProductByIdAsync(id);

        public async ValueTask<Product> ModifyProductAsync(
            Product product,
           List<string> bytes64String, 
            List<string> imageFilePaths)
        {
            if (bytes64String != null)
            {
                foreach (var byte64String in bytes64String)
                {
                    string fileName = Guid.NewGuid().ToString() + ".jpg";
                    byte[] bytes = Convert.FromBase64String(byte64String);
                    var memoryStream = ConvertBytesToMemoryStream(bytes);
                    string filePath =
                            await this.fileProcessingService.UploadFileAsync(
                                memoryStream, fileName);

                    product.Images.Add(filePath);
                }
            }

            if (imageFilePaths != null)
            {
                foreach (var imageFilePath in imageFilePaths)
                {
                    product.Images.Remove(imageFilePath);
                    string imageName = Path.GetFileName(imageFilePath);
                    this.fileProcessingService.DeleteImageFile(imageName);
                }
            }

            if (product.ProductAttributes != null)
            {
                foreach (var attribute in product.ProductAttributes)
                {
                    var productAttribute = await this.productAttributeService.RetrieveProductAttributeByIdAsync(attribute.ProductAttributeId);
                    if (productAttribute != null)
                        await this.productAttributeService.ModifyProductAttributeAsync(attribute);
                    else
                        await this.productAttributeService.AddProductAttributeAsync(attribute);
                }
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

        public MemoryStream ConvertBytesToMemoryStream(byte[] bytes)
        {
            MemoryStream memoryStream = new MemoryStream(bytes);
            return memoryStream;
        }
    }
}