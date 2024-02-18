using MeneMarket.Models.Foundations.DonationBoxes;
using MeneMarket.Services.Foundations.DonationBoxes;

namespace MeneMarket.Services.Processings.DonationBoxes
{
    public class DonationBoxProcessingService : IDonationBoxProcessingService
    {
        private readonly IDonationBoxService donationBoxService;

        public DonationBoxProcessingService(IDonationBoxService donationBoxService)
        {
            this.donationBoxService = donationBoxService;
        }

        public async ValueTask<DonationBox> AddDonationBoxAsync(DonationBox donationBox) =>
            await this.donationBoxService.AddDonationBoxAsync(donationBox);

        public IQueryable<DonationBox> RetrieveAllDonationBoxs() =>
            this.donationBoxService.RetrieveAllDonationBoxes();

        public async ValueTask<DonationBox> RetrieveDonationBoxByIdAsync(Guid id) =>
            await this.donationBoxService.RetrieveDonationBoxByIdAsync(id);

        public async ValueTask<DonationBox> ModifyDonationBoxAsync(DonationBox donationBox) =>
            await this.donationBoxService.ModifyDonationBoxAsync(donationBox);

        public async ValueTask<DonationBox> RemoveDonationBoxByIdAsync(Guid id) =>
            await this.donationBoxService.RemoveDonationBoxAsync(id);
    }
}