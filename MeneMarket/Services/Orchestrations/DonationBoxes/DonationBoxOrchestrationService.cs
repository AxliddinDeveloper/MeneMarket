using MeneMarket.Models.Foundations.DonationBoxes;
using MeneMarket.Models.Foundations.Products;
using MeneMarket.Models.Foundations.Users;
using MeneMarket.Services.Foundations.DonationBoxes;
using MeneMarket.Services.Foundations.OfferLinks;
using MeneMarket.Services.Orchestrations.Users;
using MeneMarket.Services.Processings.Products;

namespace MeneMarket.Services.Orchestrations.DonationBoxes
{
    public class DonationBoxOrchestrationService : IDonationBoxOrchestrationService
    {
        private readonly IDonationBoxService donationBoxService;
        private readonly IOfferLinkService offerLinkService;
        private readonly IUserOrchestrationService userOrchestrationService;
        private readonly IProductProcessingService productProcessingService;

        public DonationBoxOrchestrationService(
            IDonationBoxService donationBoxService, 
            IOfferLinkService offerLinkService,
            IUserOrchestrationService userOrchestrationService, 
            IProductProcessingService productProcessingService)
        {
            this.donationBoxService = donationBoxService;
            this.offerLinkService = offerLinkService;
            this.userOrchestrationService = userOrchestrationService;
            this.productProcessingService = productProcessingService;
        }

        public async ValueTask<DonationBox> AddDonationBoxAsync(DonationBox donationBox) =>
            await this.donationBoxService.AddDonationBoxAsync(donationBox);

        public IQueryable<DonationBox> RetrieveAllDonationBoxes() =>
            this.donationBoxService.RetrieveAllDonationBoxes();

        public async ValueTask<DonationBox> RetrieveDonationBoxByIdAsync(Guid id) =>
            await this.donationBoxService.RetrieveDonationBoxByIdAsync(id);

        public async ValueTask<DonationBox> ModifyDonationBoxAsync(DonationBox donationBox, Guid id, bool outBalance)
        {
            var selectedOfferLink = 
                await this.offerLinkService.RetrieveOfferLinkByIdAsync(id);

            User selectedUser =
                await this.userOrchestrationService.RetrieveUserByIdAsync(selectedOfferLink.UserId);

            Product selectedProduct =
                await this.productProcessingService.RetrieveProductByIdAsync(selectedOfferLink.ProductId);

            if (selectedOfferLink == null)
            {
                throw new ArgumentException();
            }
            else if (selectedOfferLink.AllowDonation is true && outBalance is false)
            {
                donationBox.Balance += selectedOfferLink.DonationPrice;
                selectedUser.Balance += selectedProduct.AdvertisingPrice - selectedOfferLink.DonationPrice;
                await this.userOrchestrationService.ModifyUserAsync(selectedUser);

                return await this.donationBoxService.ModifyDonationBoxAsync(donationBox);
            }
            else if (selectedOfferLink.AllowDonation is true && outBalance is true)
            {
                donationBox.Balance -= selectedOfferLink.DonationPrice;
                selectedUser.Balance -= selectedProduct.AdvertisingPrice - selectedOfferLink.DonationPrice;
                await this.userOrchestrationService.ModifyUserAsync(selectedUser);

                return await this.donationBoxService.ModifyDonationBoxAsync(donationBox);
            }

            return await this.donationBoxService.ModifyDonationBoxAsync(donationBox);
        }

        public async ValueTask<DonationBox> RemoveDonationBoxByIdAsync(Guid id) =>
            await this.donationBoxService.RemoveDonationBoxAsync(id);
    }
}
