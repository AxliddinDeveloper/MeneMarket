using MeneMarket.Models.Foundations.ImageMetadatas;

namespace MeneMarket.Services.Orchestrations.Images
{
    public interface IImageOrchestrationService
    {
        ValueTask<string> StoreImageAsync(
            MemoryStream memoryStream,
            string extension, Guid homeId);

        IQueryable<ImageMetadata> RetrieveAllImageMetadatas();
        ValueTask<string> RemoveImageFileByIdAsync(Guid id);
        ValueTask<string> RemoveImageFileByFileNameAsync(string fileName);
    }
}
