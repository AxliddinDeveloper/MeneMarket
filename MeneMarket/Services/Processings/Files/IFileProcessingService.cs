namespace MeneMarket.Services.Processings.Files
{
    public interface IFileProcessingService
    {
        string DeleteImageFile(List<string> filePaths);
        ValueTask<string> UploadFileAsync(MemoryStream memoryStream, string fileName, int maxWidth, int maxHeight);
    }
}
