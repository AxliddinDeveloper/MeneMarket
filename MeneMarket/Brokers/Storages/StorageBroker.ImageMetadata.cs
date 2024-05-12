using MeneMarket.Models.Foundations.ImageMetadatas;

namespace MeneMarket.Brokers.Storages
{
    public partial class StorageBroker
    {
        public async ValueTask<ImageMetadata> InsertImageMetadataAsync(ImageMetadata imageMetadata) =>
            await InsertAsync(imageMetadata);

        public IQueryable<ImageMetadata> SelectAllImageMetadatas() =>
            SelectAll<ImageMetadata>();

        public async ValueTask<ImageMetadata> SelectImageMetadataByIdAsync(Guid id) =>
            await SelectAsync<ImageMetadata>(id);

        public async ValueTask<ImageMetadata> UpdateImageMetadataAsync(ImageMetadata imageMetadata) =>
            await UpdateAsync(imageMetadata);

        public async ValueTask<ImageMetadata> DeleteImageMetadataAsync(ImageMetadata imageMetadata) =>
            await DeleteAsync(imageMetadata);
    }
}
