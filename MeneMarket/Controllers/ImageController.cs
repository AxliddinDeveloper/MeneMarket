using MeneMarket.Services.Orchestrations.Images;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace MeneMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : RESTFulController
    {
        private readonly IImageOrchestrationService imageOrchestrationService;

        public ImageController(
            IImageOrchestrationService imageOrchestrationService)
        {
            this.imageOrchestrationService = imageOrchestrationService;
        }

        [HttpPost("upload")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UploadImage(
                   IFormFile image, Guid productId)
        {
            string imagePath;

            using (var memoryStream = new MemoryStream())
            {
                string extension = Path.GetExtension(image.FileName);
                image.CopyTo(memoryStream);
                memoryStream.Position = 0;

                imagePath = await this.imageOrchestrationService.StoreImageAsync(
                    memoryStream, extension, productId);
            }

            return Ok(imagePath);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public ActionResult<ValueTask<string>> DeleteImage(Guid imageId)
        {
            return this.imageOrchestrationService.RemoveImageFileByIdAsync(imageId);
        }
    }
}