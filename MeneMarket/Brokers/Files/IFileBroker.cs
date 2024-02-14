
namespace MeneMarket.Brokers.Files
{
    public interface IFileBroker
    {
        Task DeleteImageFile(string filePath);
        ValueTask<string> SaveFileAsync(MemoryStream memoryStream, string fileName, string uploadsFolder);
    }
}
