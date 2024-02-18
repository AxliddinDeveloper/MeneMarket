using MeneMarket.Models.Foundations.ImageMetadatas;

namespace MeneMarket.Services.Processings.Images
{
    public interface IImageMetadataProcessingService
    {
        ValueTask<ImageMetadata> AddImageMetadataAsync(ImageMetadata imageMetadata);
        IQueryable<ImageMetadata> RetrieveAllImageMetadatas();
        ValueTask<ImageMetadata> RetrieveImageMetadataByIdAsync(Guid id);
        ValueTask<ImageMetadata> ModifyImageMetadataAsync(ImageMetadata imageMetadata);
        ValueTask<ImageMetadata> RemoveImageMetadataByIdAsync(Guid id);
    }
}