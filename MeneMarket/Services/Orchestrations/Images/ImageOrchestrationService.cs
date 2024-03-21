using MeneMarket.Models.Foundations.ImageMetadatas;
using MeneMarket.Services.Processings.Files;
using MeneMarket.Services.Processings.Images;

namespace MeneMarket.Services.Orchestrations.Images
{
    public class ImageOrchestrationService : IImageOrchestrationService
    {
        private readonly IImageMetadataProcessingService imageMetadtaProcessingService;
        private readonly IFileProcessingService fileProcessingService;

        public ImageOrchestrationService(
            IImageMetadataProcessingService imageMetadtaProcessingService,
            IFileProcessingService fileProcessingService)
        {
            this.imageMetadtaProcessingService = imageMetadtaProcessingService;
            this.fileProcessingService = fileProcessingService;
        }

        public async ValueTask<string> StoreImageAsync(
            MemoryStream memoryStream,
            string extension, Guid productId)
        {
            Guid imageId = Guid.NewGuid();
            string name = imageId.ToString() + extension;

            var format =
                (ImageFormat)Enum.Parse(typeof(ImageFormat), extension.Substring(1), true);

            string filePath =
                await this.fileProcessingService.UploadFileAsync(memoryStream, name);

            var imageMetadata = new ImageMetadata
            {
                Id = imageId,
                Name = name,
                Size = memoryStream.Length,
                Format = format,
                ProductId = productId,
                FilePath = filePath,
            };

            await this.imageMetadtaProcessingService.AddImageMetadataAsync(imageMetadata);

            return imageMetadata.FilePath;
        }

        public async ValueTask<string> RemoveImageFileByIdAsync(Guid id)
        { 
            ImageMetadata image =
                await this.imageMetadtaProcessingService.RetrieveImageMetadataByIdAsync(id);

            await this.imageMetadtaProcessingService.RemoveImageMetadataByIdAsync(id);

            return this.fileProcessingService.DeleteImageFile(image.Name);
        }

        public async ValueTask<string> RemoveImageFileByFileNameAsync(string fileName) =>
            this.fileProcessingService.DeleteImageFile(fileName);

        public IQueryable<ImageMetadata> RetrieveAllImageMetadatas() =>
            this.imageMetadtaProcessingService.RetrieveAllImageMetadatas();
    }
}