namespace MeneMarket.Brokers.Files
{
    public class FileBroker : IFileBroker
    {
        public async ValueTask<string> SaveFileAsync(
            MemoryStream memoryStream, string fileName, string uploadsFolder)
        {
            string filePath = Path.Combine(uploadsFolder, fileName);
            var relativePath = Path.Combine("images", fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                await memoryStream.CopyToAsync(fileStream);
            }

            return relativePath;
        }

        public Task DeleteImageFile(string filePath)
        {
            System.IO.File.Delete(filePath);

            return Task.CompletedTask;
        }
    }
}