using MeneMarket.Services.Orchestrations.Clients;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace MeneMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StreamController : RESTFulController
    {
        private readonly IClientOrchestrationService clientOrchestrationService;

        public StreamController(IClientOrchestrationService clientOrchestrationService)
        {
            this.clientOrchestrationService = clientOrchestrationService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<string>> GetAction(Guid id)
        {
            var httpContext = HttpContext;

            string ipAddress = httpContext.Connection.RemoteIpAddress?.ToString();

            var productLink =
                await this.clientOrchestrationService.AddClientAsync(id, ipAddress);

            return Ok(productLink);
        }
    }
}