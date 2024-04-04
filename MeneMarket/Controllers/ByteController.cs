using MeneMarket.Services.Foundations.Files;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace MeneMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ByteController : RESTFulController
    {
        [HttpPost]
        public async Task<IActionResult> UploadByte(string base64String)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(base64String);
                string fileName = Guid.NewGuid().ToString() + ".jpg";
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
                await System.IO.File.WriteAllBytesAsync(filePath, bytes);

                return Ok(fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
