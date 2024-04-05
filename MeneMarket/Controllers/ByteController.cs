using MeneMarket.Models.Orchestrations.ImageBytes;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace MeneMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ByteController : RESTFulController
    {
        [HttpPost]
        [Route("Upload")]
        public async ValueTask<string> UploadByte(ImageBytes imageBytes)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(imageBytes.Byte64String);
                string fileName =  "yuklanganrasm.jpg";
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
                await System.IO.File.WriteAllBytesAsync(filePath, bytes);
                int sizeInBytes = System.Text.Encoding.Unicode.GetByteCount(imageBytes.Byte64String);
                return $"{fileName} -------- {sizeInBytes}";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}