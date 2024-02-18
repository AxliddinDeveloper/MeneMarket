using MeneMarket.Models.Foundations.DonationBoxes;
using MeneMarket.Services.Processings.DonationBoxes;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace MeneMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationBoxController : RESTFulController
    {
        private readonly IDonationBoxProcessingService donationBoxProcessingService;

        public DonationBoxController(IDonationBoxProcessingService donationBoxProcessingService)
        {
            this.donationBoxProcessingService = donationBoxProcessingService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<DonationBox>> PostDonationBoxAsync(DonationBox donationBox) =>
            await this.donationBoxProcessingService.AddDonationBoxAsync(donationBox);

        [HttpGet]
        public ActionResult<IQueryable<DonationBox>> GelAllDonationBoxs()
        {
            IQueryable<DonationBox> allUDonationBoxs =
                this.donationBoxProcessingService.RetrieveAllDonationBoxs();

            return Ok(allUDonationBoxs);
        }

        [HttpGet("ById")]
        public async ValueTask<ActionResult<DonationBox>> GetDonationBoxByIdAsync(Guid id) =>
            await this.donationBoxProcessingService.RetrieveDonationBoxByIdAsync(id);

        [HttpPut]
        public async ValueTask<ActionResult<DonationBox>> PutDonationBoxAsync(DonationBox donationBox) =>
            await this.donationBoxProcessingService.ModifyDonationBoxAsync(donationBox);

        [HttpDelete]
        public async ValueTask<ActionResult<DonationBox>> DeleteDonationBoxAsync(Guid id) =>
            await this.donationBoxProcessingService.RemoveDonationBoxByIdAsync(id);
    }
}