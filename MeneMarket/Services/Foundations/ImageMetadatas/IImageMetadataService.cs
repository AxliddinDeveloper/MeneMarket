using MeneMarket.Models.Foundations.ImageMetadatas;

namespace MeneMarket.Services.Foundations.ImageMetadatas
{
    public interface IImageMetadataService
    {
        ValueTask<ImageMetadata> AddImageMetadataAsync(ImageMetadata imageMetadatas);
        IQueryable<ImageMetadata> RetrieveAllImageMetadatas();
        ValueTask<ImageMetadata> RetrieveImageMetadataByIdAsync(Guid id);
        ValueTask<ImageMetadata> ModifyImageMetadataAsync(ImageMetadata imageMetadata);
        ValueTask<ImageMetadata> RemoveImageMetadataByIdAsync(Guid id);
    }
}
