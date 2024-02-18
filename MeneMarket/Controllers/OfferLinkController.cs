using MeneMarket.Models.Foundations.OfferLinks;
using MeneMarket.Services.Foundations.OfferLinks;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace MeneMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfferLinkController : RESTFulController
    {
        private readonly IOfferLinkService offerLinkService;
        [HttpPost]
        public async ValueTask<ActionResult<OfferLink>> PostOfferLinkAsync(OfferLink offerLink) =>
            await this.offerLinkService.AddOfferLinkAsync(offerLink);

        [HttpGet]
        public async Task<List<OfferLink>> GelAllOfferLinksAsync() =>
            await this.offerLinkService.RetrieveAllOfferLinksAsync();

        [HttpGet("ById")]
        public async ValueTask<ActionResult<OfferLink>> GetOfferLinkByIdAsync(Guid id) =>
            await this.offerLinkService.RetrieveOfferLinkByIdAsync(id);

        [HttpPut]
        public async ValueTask<ActionResult<OfferLink>> PutOfferLinkAsync(OfferLink offerLink) =>
            await this.offerLinkService.ModifyOfferLinkAsync(offerLink);

        [HttpDelete]
        public async ValueTask<ActionResult<OfferLink>> DeleteOfferLinkAsync(Guid id) =>
            await this.offerLinkService.RemoveOfferLinkAsync(id);
    }
}