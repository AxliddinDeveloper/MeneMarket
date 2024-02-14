using MeneMarket.Services.Foundations.Files;

namespace MeneMarket.Services.Processings.Files
{
    public class FileProcessingService : IFileProcessingService
    {
        private readonly IFileService fileService;

        public FileProcessingService(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public async ValueTask<string> UploadFileAsync(
            MemoryStream memoryStream,
            string fileName)
        {
            var uploadsFolder =
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imageFiles");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            return await this.fileService.UploadFileAsync(memoryStream, fileName, uploadsFolder);
        }

        public string DeleteImageFile(string imageName)
        {
            string filePath = Path.Combine("wwwroot\\imageFiles", imageName);

            if (System.IO.File.Exists(filePath))
            {
                this.fileService.RemoveImageFile(filePath);
                return "Image deleted successfully.";
            }
            else
            {
                return "Image not found.";
            }
        }
    }
}
