using MeneMarket.Models.Foundations.ProductTypes;
using MeneMarket.Models.Foundations.Products;
using MeneMarket.Services.Foundations.ProductTypes;
using MeneMarket.Services.Processings.Files;
using MeneMarket.Services.Processings.Products;
using MeneMarket.Services.Foundations.ImageMetadatas;
using MeneMarket.Models.Foundations.ImageMetadatas;

namespace MeneMarket.Services.Orchestrations.Products
{
    public class ProductOrchestrationService : IProductOrchestrationService
    {
        private readonly IProductProcessingService productProcessingService;
        private readonly IProductTypeService ProductTypeService;
        private readonly IFileProcessingService fileProcessingService;
        private readonly IImageMetadataService imageMetadataService;

        public ProductOrchestrationService(
            IProductProcessingService productProcessingService,
            IFileProcessingService fileProcessingService,
            IProductTypeService ProductTypeService,
            IImageMetadataService imageMetadataService)
        {
            this.productProcessingService = productProcessingService;
            this.ProductTypeService = ProductTypeService;
            this.fileProcessingService = fileProcessingService;
            this.imageMetadataService = imageMetadataService;
        }

        public async ValueTask<Product> AddProductAsync(Product product,
            List<string> bytes64String)
        {
            product.ProductId = Guid.NewGuid();

            if (product.ProductTypes == null)
                throw new ArgumentNullException("Product Type is null");

            var storedProduct =
               await this.productProcessingService.AddProductAsync(product);

            if (bytes64String != null)
            {
                foreach (var byte64String in bytes64String)
                {
                    string fileName = Guid.NewGuid().ToString() + ".webp";
                    byte[] bytes = Convert.FromBase64String(byte64String);
                    var memoryStream = ConvertBytesToMemoryStream(bytes);
                    string filePath =
                            await this.fileProcessingService.UploadFileAsync(
                                memoryStream, fileName);

                    ImageMetadata imageMetadata = new ImageMetadata
                    {
                        Id = Guid.NewGuid(),
                        FilePath = filePath,
                        ProductId = product.ProductId,
                    };

                    await this.imageMetadataService.AddImageMetadataAsync(imageMetadata);
                }
                await this.productProcessingService.ModifyProductAsync(storedProduct);
            }

            if (product.ProductTypes != null)
            {
                foreach (var attribute in storedProduct.ProductTypes)
                {
                    var ProductType = new ProductType
                    {
                        Product = storedProduct,
                        Count = attribute.Count,
                        ProductId = storedProduct.ProductId
                    };

                    await this.ProductTypeService.AddProductTypeAsync(ProductType);
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
           List<string> bytes64String)
        {
            if (product.ProductTypes == null)
                throw new ArgumentNullException("Product Type is null");

            var storedProduct =
               await this.productProcessingService.RetrieveProductByIdAsync(product.ProductId);

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

                    ImageMetadata imageMetadata = new ImageMetadata
                    {
                        Id = Guid.NewGuid(),
                        FilePath = filePath,
                        ProductId = product.ProductId,
                    };

                    await this.imageMetadataService.AddImageMetadataAsync(imageMetadata);
                }

                var AllImageMetadatas =
                   this.imageMetadataService.RetrieveAllImageMetadatas();

                foreach (var imageMetadata in AllImageMetadatas)
                {
                    if (imageMetadata.ProductId == product.ProductId)
                    {
                        var selectedimageMetadata = 
                            product.ImageMetadatas.FirstOrDefault(i => i.Id == imageMetadata.Id);

                        if (selectedimageMetadata == null)
                            await this.imageMetadataService.RemoveImageMetadataByIdAsync(imageMetadata.Id);
                    }
                }
            }

             foreach (var attribute in product.ProductTypes)
             {
                 var ProductType = await this.ProductTypeService.RetrieveProductTypeByIdAsync(attribute.ProductTypeId);
                 if (ProductType != null && ProductType != attribute)
                     await this.ProductTypeService.ModifyProductTypeAsync(attribute);
                 else if (ProductType == null)
                     await this.ProductTypeService.AddProductTypeAsync(attribute);
             }

            var AllProductTypes = 
                this.ProductTypeService.RetrieveAllProductTypes();

            foreach (var productType in AllProductTypes)
            {
                if (productType.ProductId == product.ProductId)
                {
                    var selectedProductType = 
                        product.ProductTypes.FirstOrDefault(t => t.ProductTypeId == productType.ProductId);

                    if (selectedProductType == null)
                        await this.ProductTypeService.RemoveProductTypeAsync(productType.ProductTypeId);
                }
            }

            return await this.productProcessingService.ModifyProductAsync(product);
        }

        public async ValueTask<Product> RemoveProductAsync(Guid id)
        {
            var product =
                await this.productProcessingService.RetrieveProductByIdAsync(id);

            //foreach (var imageFilePath in product.Images)
            //{
            //    string imageName = imageFilePath.Replace(@"imageFiles\\", "");
            //    fileProcessingService.DeleteImageFile(imageName);
            //}

            return await this.productProcessingService.RemoveProductByIdAsync(id);
        }

        public MemoryStream ConvertBytesToMemoryStream(byte[] bytes)
        {
            MemoryStream memoryStream = new MemoryStream(bytes);
            return memoryStream;
        }
    }
}