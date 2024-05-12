using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace MeneMarket.Brokers.Files
{
    public class FileBroker : IFileBroker
    {
        public async ValueTask<string> SaveFileAsync(
            MemoryStream memoryStream, string fileName, string uploadsFolder)
        {
            int maxWidth = 600;
            int maxHeight = 800;
            string filePath = Path.Combine(uploadsFolder, fileName);
            var relativePath = Path.Combine("imageFiles", fileName);

            using (var resizedStream = ResizeAndConvertToWebP(memoryStream, maxWidth, maxHeight))
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    resizedStream.Seek(0, SeekOrigin.Begin);
                    await resizedStream.CopyToAsync(fileStream);
                }
            }

            return relativePath;
        }

        public Task DeleteImageFile(string filePath)
        {
            System.IO.File.Delete(filePath);

            return Task.CompletedTask;
        }

        public MemoryStream ResizeAndConvertToWebP(MemoryStream memoryStream, int maxWidth, int maxHeight)
        {
            using (Image image = Image.Load(memoryStream))
            {
                image.Mutate(x => x.Resize(maxWidth, maxHeight));

                MemoryStream resultStream = new MemoryStream();
                image.SaveAsWebp(resultStream);
                resultStream.Position = 0;

                return resultStream;
            }
        }

    }
}