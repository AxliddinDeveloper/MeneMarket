using MeneMarket.Models.Foundations.DonationBoxes;
using MeneMarket.Services.Foundations.OfferLinks;
using MeneMarket.Services.Orchestrations.Users;
using MeneMarket.Services.Processings.DonationBoxes;
using MeneMarket.Services.Processings.Products;

namespace MeneMarket.Services.Orchestrations.DonationBoxes
{
    public class DonationBoxOrchestrationService : IDonationBoxOrchestrationService
    {
        private readonly IOfferLinkService offerLinkService;
        private readonly IUserOrchestrationService userOrchestrationService;
        private readonly IProductProcessingService productProcessingService;
        private readonly IDonationBoxProcessingService donationBoxProcessingService;

        public DonationBoxOrchestrationService(
            IOfferLinkService offerLinkService, 
            IUserOrchestrationService userOrchestrationService, 
            IProductProcessingService productProcessingService, 
            IDonationBoxProcessingService donationBoxProcessingService)
        {
            this.offerLinkService = offerLinkService;
            this.userOrchestrationService = userOrchestrationService;
            this.productProcessingService = productProcessingService;
            this.donationBoxProcessingService = donationBoxProcessingService;
        }

        public async ValueTask<DonationBox> AddDonationBoxAsync(DonationBox donationBox) =>
            await this.donationBoxProcessingService.AddDonationBoxAsync(donationBox);

        public IQueryable<DonationBox> RetrieveAllDonationBoxes() =>
            this.donationBoxProcessingService.RetrieveAllDonationBoxs();

        public async ValueTask<DonationBox> RetrieveDonationBoxByIdAsync(Guid id) =>
            await this.donationBoxProcessingService.RetrieveDonationBoxByIdAsync(id);

        public async ValueTask<DonationBox> ModifyDonationBoxAsync(
            DonationBox donationBox, 
            Guid id, bool outBalance)
        {
            var selectedOfferLink = 
                await this.offerLinkService.RetrieveOfferLinkByIdAsync(id);

            var selectedUser =
                await this.userOrchestrationService.RetrieveUserByIdAsync(selectedOfferLink.UserId);

            var selectedProduct =
                await this.productProcessingService.RetrieveProductByIdAsync(selectedOfferLink.ProductId);

            if (selectedOfferLink == null)
            {
                throw new ArgumentException();
            }
            else if (selectedOfferLink.AllowDonation is true && outBalance is false)
            {
                decimal profit = selectedProduct.AdvertisingPrice - selectedOfferLink.DonationPrice;
                donationBox.Balance += selectedOfferLink.DonationPrice;
                selectedUser.Balance += profit;
                await this.userOrchestrationService.ModifyUserAsync(selectedUser);

                return await this.donationBoxProcessingService.ModifyDonationBoxAsync(donationBox);
            }
            else if (selectedOfferLink.AllowDonation is true && outBalance is true)
            {
                decimal profit = selectedProduct.AdvertisingPrice - selectedOfferLink.DonationPrice;
                donationBox.Balance -= selectedOfferLink.DonationPrice;
                selectedUser.Balance -= profit;
                await this.userOrchestrationService.ModifyUserAsync(selectedUser);

                return await this.donationBoxProcessingService.ModifyDonationBoxAsync(donationBox);
            }

            return await this.donationBoxProcessingService.ModifyDonationBoxAsync(donationBox);
        }

        public async ValueTask<DonationBox> RemoveDonationBoxByIdAsync(Guid id) =>
            await this.donationBoxProcessingService.RemoveDonationBoxByIdAsync(id);
    }
}
