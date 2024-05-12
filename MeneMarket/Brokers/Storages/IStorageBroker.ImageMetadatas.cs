using MeneMarket.Models.Foundations.ImageMetadatas;

namespace MeneMarket.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<ImageMetadata> InsertImageMetadataAsync(ImageMetadata imageMetadata);
        IQueryable<ImageMetadata> SelectAllImageMetadatas();
        ValueTask<ImageMetadata> SelectImageMetadataByIdAsync(Guid id);
        ValueTask<ImageMetadata> UpdateImageMetadataAsync(ImageMetadata imageMetadata);
        ValueTask<ImageMetadata> DeleteImageMetadataAsync(ImageMetadata imageMetadata);
    }
}
