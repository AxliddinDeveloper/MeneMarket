using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OqimController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Redirect(string id)
        {
            return Redirect("https://localhost:7152/api/Product");
        }
    }
}