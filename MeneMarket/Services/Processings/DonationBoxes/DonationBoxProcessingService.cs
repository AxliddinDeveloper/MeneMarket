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


    }
}