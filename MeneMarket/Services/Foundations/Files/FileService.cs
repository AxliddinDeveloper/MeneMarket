using MeneMarket.Brokers.Files;

namespace MeneMarket.Services.Foundations.Files
{
    public class FileService : IFileService
    {
        private readonly IFileBroker fileBroker;

        public FileService(IFileBroker fileBroker)
        {
            this.fileBroker = fileBroker;
        }

        public ValueTask<string> UploadFileAsync(
            MemoryStream memoryStream, string fileName, string uploadsFolder) =>
            this.fileBroker.SaveFileAsync(memoryStream, fileName, uploadsFolder);

        public Task RemoveImageFile(string filePath) =>
            this.fileBroker.DeleteImageFile(filePath);
    }
}