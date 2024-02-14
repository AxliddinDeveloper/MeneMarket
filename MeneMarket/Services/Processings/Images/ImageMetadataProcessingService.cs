using MeneMarket.Models.Foundations.ImageMetadatas;
using MeneMarket.Services.Foundations.ImageMetadatas;

namespace MeneMarket.Services.Processings.Images
{
    public class ImageMetadataProcessingService : IImageMetadataProcessingService
    {
        private readonly IImageMetadataService imageMetadataService;

        public ImageMetadataProcessingService(
            IImageMetadataService imageMetadataService)
        {
            this.imageMetadataService = imageMetadataService;
        }

        public async ValueTask<ImageMetadata> AddImageMetadataAsync(ImageMetadata imageMetadata) =>
            await this.imageMetadataService.AddImageMetadataAsync(imageMetadata);

        public IQueryable<ImageMetadata> RetrieveAllImageMetadatas() =>
            this.RetrieveAllImageMetadatas();

        public async ValueTask<ImageMetadata> RetrieveImageMetadataByIdAsync(Guid id) =>
            await this.imageMetadataService.RetrieveImageMetadataByIdAsync(id);

        public async ValueTask<ImageMetadata> ModifyImageMetadataAsync(ImageMetadata imageMetadata) =>
            await this.imageMetadataService.ModifyImageMetadataAsync(imageMetadata);

        public async ValueTask<ImageMetadata> RemoveImageMetadataByIdAsync(Guid id)
        {
            ImageMetadata imageMetadata =
                await this.imageMetadataService.RetrieveImageMetadataByIdAsync(id);

            return await this.imageMetadataService.RemoveImageMetadataAsync(imageMetadata);
        }
    }
}
