using MeneMarket.Models.Foundations.OfferLinks;
using MeneMarket.Services.Foundations.OfferLinks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace MeneMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfferLinkController : RESTFulController
    {
        private readonly IOfferLinkService offerLinkService;

        public OfferLinkController(IOfferLinkService offerLinkService)
        {
            this.offerLinkService = offerLinkService;
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async ValueTask<ActionResult<OfferLink>> PostOfferLinkAsync(OfferLink offerLink) =>
            await this.offerLinkService.AddOfferLinkAsync(offerLink);

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<List<OfferLink>> GelAllOfferLinksAsync() =>
            await this.offerLinkService.RetrieveAllOfferLinksAsync();

        [HttpGet("ById")]
        [Authorize(Roles = "Admin,User")]
        public async ValueTask<ActionResult<OfferLink>> GetOfferLinkByIdAsync(Guid id) =>
            await this.offerLinkService.RetrieveOfferLinkByIdAsync(id);

        [HttpPut]
        [Authorize(Roles = "Admin,User")]
        public async ValueTask<ActionResult<OfferLink>> PutOfferLinkAsync(OfferLink offerLink) =>
            await this.offerLinkService.ModifyOfferLinkAsync(offerLink);

        [HttpDelete]
        [Authorize(Roles = "Admin,User")]
        public async ValueTask<ActionResult<OfferLink>> DeleteOfferLinkAsync(Guid id) =>
            await this.offerLinkService.RemoveOfferLinkAsync(id);
    }
}