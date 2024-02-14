using MeneMarket.Brokers.Storages;
using MeneMarket.Models.Foundations.ImageMetadatas;

namespace MeneMarket.Services.Foundations.ImageMetadatas
{
    public class ImageMetadataService : IImageMetadataService
    {
        private readonly IStorageBroker storageBroker;

        public ImageMetadataService(
            IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<ImageMetadata> AddImageMetadataAsync(ImageMetadata imageMetadata) =>
            await this.storageBroker.InsertImageMetadataAsync(imageMetadata);

        public IQueryable<ImageMetadata> RetrieveAllImageMetadatas() =>
            this.storageBroker.SelectAllImageMetadatas();

        public async ValueTask<ImageMetadata> RetrieveImageMetadataByIdAsync(Guid id) =>
            await this.storageBroker.SelectImageMetadataByIdAsync(id);

        public async ValueTask<ImageMetadata> ModifyImageMetadataAsync(ImageMetadata imageMetadata) =>
            await this.storageBroker.UpdateImageMetadataAsync(imageMetadata);

        public async ValueTask<ImageMetadata> RemoveImageMetadataAsync(ImageMetadata imageMetadata) =>
            await this.storageBroker.DeleteImageMetadataAsync(imageMetadata);
    }
}
