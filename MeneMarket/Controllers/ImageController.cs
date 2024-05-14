using MeneMarket.Models.Foundations.Users;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MeneMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        [HttpPost("byte-weighted")]
        public async ValueTask<ActionResult<string>> GetImageBytes(IFormFile imageFile)
        {
            try
            {
                if (imageFile == null || imageFile.Length == 0)
                    return BadRequest("No image file provided.");

                using (var memoryStream = new MemoryStream())
                {
                    // Copy the image file to the memory stream
                    await imageFile.CopyToAsync(memoryStream);

                    // Get the byte array from the memory stream
                    byte[] imageBytes = memoryStream.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);

                    // Return the byte array as the response
                    return base64String;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
    }
}
