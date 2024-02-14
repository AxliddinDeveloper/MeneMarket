namespace MeneMarket.Services.Processings.Files
{
    public interface IFileProcessingService
    {
        string DeleteImageFile(string imageName);
        ValueTask<string> UploadFileAsync(MemoryStream memoryStream, string fileName);
    }
}
