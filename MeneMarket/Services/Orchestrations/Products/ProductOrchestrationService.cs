using MeneMarket.Models.Foundations.ImageMetadatas;
using MeneMarket.Models.Foundations.Products;
using MeneMarket.Models.Foundations.ProductTypes;
using MeneMarket.Models.Orchestrations.CombinedProducts;
using MeneMarket.Services.Foundations.ImageMetadatas;
using MeneMarket.Services.Foundations.ProductTypes;
using MeneMarket.Services.Processings.Files;
using MeneMarket.Services.Processings.Products;

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
            product.CreatedDate = DateTime.Now;

            if (product.ProductTypes == null)
                throw new ArgumentNullException("Product Type is null");

            var storedProduct =
               await this.productProcessingService.AddProductAsync(product);

            if (bytes64String != null)
            {
                foreach (var byte64String in bytes64String)
                {
                    string lowFileName = Guid.NewGuid().ToString() + ".WebP";
                    string mediumFileName = Guid.NewGuid().ToString() + ".WebP";
                    string highFileName = Guid.NewGuid().ToString() + ".WebP"; // Corrected typo
                    byte[] bytes = Convert.FromBase64String(byte64String);

                    // Create a new MemoryStream for each image size
                    using (var memoryStream = new MemoryStream(bytes))
                    {
                        string lowImageFilePath =
                            await this.fileProcessingService.UploadFileAsync(
                                memoryStream, lowFileName, 600, 600);

                        // Reset the position of the MemoryStream back to the beginning
                        memoryStream.Seek(0, SeekOrigin.Begin);

                        string mediumImageFilePath =
                            await this.fileProcessingService.UploadFileAsync(
                                memoryStream, mediumFileName, 700, 700);

                        // Reset the position of the MemoryStream back to the beginning
                        memoryStream.Seek(0, SeekOrigin.Begin);

                        string highImageFilePath =
                            await this.fileProcessingService.UploadFileAsync(
                                memoryStream, highFileName, 1080, 1440);

                        ImageMetadata imageMetadata = new ImageMetadata
                        {
                            Id = Guid.NewGuid(),
                            LowImageFilePath = lowImageFilePath,
                            MediumImageFilePath = mediumImageFilePath,
                            HightImageFilePath = highImageFilePath, // Corrected typo
                            ProductId = product.ProductId,
                        };

                        await this.imageMetadataService.AddImageMetadataAsync(imageMetadata);
                    }
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

        public CombinedProducts RetrieveAllProducts(int userRole)
        {
            var allProducts = this.productProcessingService.RetrieveAllProducts();
            var finishedProducts = allProducts.Where(product => product.ProductTypes == null);

            if (finishedProducts != null) 
            {
                foreach (var product in finishedProducts)
                {
                    product.IsArchived = true;
                    this.productProcessingService.ModifyProductAsync(product);
                }
            }

            if (userRole == 0) 
            {
                var nonArchivedProducts = allProducts.Where(product => !product.IsArchived);
                var newNonArchivedProducts = nonArchivedProducts.OrderByDescending(product => product.CreatedDate).Take(20);
                var orderedProducts = nonArchivedProducts.OrderByDescending(product => product.NumberSold);
                var mostSoldProduct = orderedProducts.FirstOrDefault();
                var top20SoldProducts = orderedProducts.Take(20);

                var combinedProducts = new CombinedProducts
                {
                    AllProducts = nonArchivedProducts,
                    NewProducts = newNonArchivedProducts,
                    PopularProducts = top20SoldProducts,
                };

                return combinedProducts;
            }
            else
            {
                var newAllProducts = allProducts.OrderByDescending(product => product.CreatedDate).Take(20);
                var orderedProducts = allProducts.OrderByDescending(product => product.NumberSold);
                var mostSoldProduct = orderedProducts.FirstOrDefault();
                var top20SoldProducts = orderedProducts.Take(20);

                var combinedProducts = new CombinedProducts
                {
                    AllProducts = allProducts,
                    NewProducts = newAllProducts,
                    PopularProducts = top20SoldProducts,
                };

                return combinedProducts;
            }
        }

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
                    string fileName = Guid.NewGuid().ToString() + ".WebP";
                    byte[] bytes = Convert.FromBase64String(byte64String);
                    var memoryStream = ConvertBytesToMemoryStream(bytes);

                    string lowImageFilePath =
                            await this.fileProcessingService.UploadFileAsync(
                                memoryStream, fileName, 600, 600);
                    string mediumImageFilePath =
                        await this.fileProcessingService.UploadFileAsync(
                            memoryStream, fileName, 700, 700);
                    string hightImageFilePath =
                        await this.fileProcessingService.UploadFileAsync(
                            memoryStream, fileName, 1080, 1440);

                    ImageMetadata imageMetadata = new ImageMetadata
                    {
                        Id = Guid.NewGuid(),
                        LowImageFilePath = lowImageFilePath,
                        MediumImageFilePath = mediumImageFilePath,
                        HightImageFilePath = hightImageFilePath,
                        ProductId = product.ProductId,
                    };

                    await this.imageMetadataService.AddImageMetadataAsync(imageMetadata);

                    var AllImageMetadatas =
                   this.imageMetadataService.RetrieveAllImageMetadatas();

                    foreach (var imagedata in AllImageMetadatas)
                    {
                        if (imagedata.ProductId == product.ProductId)
                        {
                            var selectedimageMetadata =
                                product.ImageMetadatas.FirstOrDefault(i => i.Id == imagedata.Id);

                            if (selectedimageMetadata == null)
                                await this.imageMetadataService.RemoveImageMetadataByIdAsync(imagedata.Id);
                        }
                    }
                }

                foreach (var attribute in product.ProductTypes)
                {
                    var productType = await this.ProductTypeService.RetrieveProductTypeByIdAsync(attribute.ProductTypeId);
                    if (productType != attribute)
                        await this.ProductTypeService.ModifyProductTypeAsync(attribute);
                    else if (productType == null)
                        await this.ProductTypeService.AddProductTypeAsync(attribute);
                }
            }

            return await this.productProcessingService.ModifyProductAsync(product);
        }

        public async ValueTask<Product> RemoveProductAsync(Guid id)
        {
            var product =
                await this.productProcessingService.RetrieveProductByIdAsync(id);

            foreach (var imageMetadata in product.ImageMetadatas)
            {
                string lowImageName = imageMetadata.LowImageFilePath.Replace(@"imageFiles\\", "");
                string mediumImageName = imageMetadata.MediumImageFilePath.Replace(@"imageFiles\\", "");
                string hightmageName = imageMetadata.HightImageFilePath.Replace(@"imageFiles\\", "");
                List<string> imageFilePaths = new List<string>();
                imageFilePaths.Add(lowImageName);
                imageFilePaths.Add(mediumImageName);
                imageFilePaths.Add(hightmageName);
                fileProcessingService.DeleteImageFile(imageFilePaths);
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