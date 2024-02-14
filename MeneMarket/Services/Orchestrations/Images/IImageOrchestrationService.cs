namespace MeneMarket.Services.Orchestrations.Images
{
    public interface IImageOrchestrationService
    {
        ValueTask<string> RemoveImageFileByIdAsync(Guid id);

        ValueTask<string> StoreImageAsync(
            MemoryStream memoryStream,
            string extension, Guid homeId);
    }
}
