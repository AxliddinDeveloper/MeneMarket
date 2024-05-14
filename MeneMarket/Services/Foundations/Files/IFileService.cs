namespace MeneMarket.Services.Foundations.Files
{
    public interface IFileService
    {
        Task RemoveImageFile(string filePath);
        ValueTask<string> UploadFileAsync(
            MemoryStream memoryStream,
            string fileName, string uploadsFolder, int maxWidth, int maxHeight);
    }
}