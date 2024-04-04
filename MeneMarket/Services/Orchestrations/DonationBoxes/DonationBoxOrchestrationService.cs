using MeneMarket.Models.Foundations.DonatedUsers;
using MeneMarket.Models.Foundations.DonationBoxes;
using MeneMarket.Models.Orchestrations.UserWithImages;
using MeneMarket.Services.Foundations.DonatedUsers;
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
        private readonly IDonatedUserService donatedUserService;

        public DonationBoxOrchestrationService(
            IOfferLinkService offerLinkService,
            IUserOrchestrationService userOrchestrationService,
            IProductProcessingService productProcessingService,
            IDonationBoxProcessingService donationBoxProcessingService,
            IDonatedUserService donatedUserService)
        {
            this.offerLinkService = offerLinkService;
            this.userOrchestrationService = userOrchestrationService;
            this.productProcessingService = productProcessingService;
            this.donationBoxProcessingService = donationBoxProcessingService;
            this.donatedUserService = donatedUserService;
        }

        public async ValueTask<DonationBox> AddDonationBoxAsync(DonationBox donationBox)
        {
            donationBox.DonationBoxId = Guid.NewGuid();
            return await this.donationBoxProcessingService.AddDonationBoxAsync(donationBox);
        }

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
                throw new NullReferenceException("Taklif Qilish havolasi topilmadi!");
            }
            else if (selectedOfferLink.AllowDonation is true && outBalance is false)
            {
                decimal profit = selectedProduct.AdvertisingPrice - selectedOfferLink.DonationPrice;
                donationBox.Balance += selectedOfferLink.DonationPrice;
                selectedUser.Balance += profit;

                IQueryable<DonatedUser> allDonatedUsers =
                  this.donatedUserService.RetrieveAllDonatedUsers();

                DonatedUser ExsistsDonatedUsers =
                    allDonatedUsers.FirstOrDefault(d =>
                        d.UserId == selectedUser.UserId);

                DonatedUser donatedUser = new DonatedUser
                {
                    Id = Guid.NewGuid(),
                    DonationBoxId = donationBox.DonationBoxId,
                    UserId = selectedUser.UserId
                };

                if (ExsistsDonatedUsers == null)
                {
                    donatedUser.DonationPrice += selectedOfferLink.DonationPrice;
                    await this.donatedUserService.AddDonatedUserAsync(donatedUser);
                }
                else if (ExsistsDonatedUsers.UserId == selectedUser.UserId && ExsistsDonatedUsers.DonationBoxId == donationBox.DonationBoxId)
                {
                    ExsistsDonatedUsers.DonationPrice += selectedOfferLink.DonationPrice;
                    await this.donatedUserService.ModifyDonatedUserAsync(donatedUser);
                }
                var userWithImages = new UserWithImages
                {
                    User = selectedUser,
                };
                await this.userOrchestrationService.ModifyUserAsync(userWithImages);

                return await this.donationBoxProcessingService.ModifyDonationBoxAsync(donationBox);
            }
            else if (selectedOfferLink.AllowDonation is true && outBalance is true)
            {
                decimal profit = selectedProduct.AdvertisingPrice - selectedOfferLink.DonationPrice;
                donationBox.Balance -= selectedOfferLink.DonationPrice;
                selectedUser.Balance -= profit;

                IQueryable<DonatedUser> allDonatedUsers =
                    this.donatedUserService.RetrieveAllDonatedUsers();

                DonatedUser ExsistsdonatedUsers =
                    allDonatedUsers.FirstOrDefault(d =>
                        d.UserId == selectedUser.UserId &&
                        d.DonationBoxId == donationBox.DonationBoxId);

                if (ExsistsdonatedUsers != null)
                {
                    ExsistsdonatedUsers.DonationPrice -= selectedOfferLink.DonationPrice;
                    await this.donatedUserService.ModifyDonatedUserAsync(ExsistsdonatedUsers);
                }

                var userWithImages = new UserWithImages
                {
                    User = selectedUser,
                };
                await this.userOrchestrationService.ModifyUserAsync(userWithImages);

                return await this.donationBoxProcessingService.ModifyDonationBoxAsync(donationBox);
            }

            return await this.donationBoxProcessingService.ModifyDonationBoxAsync(donationBox);
        }

        public async ValueTask<DonationBox> RemoveDonationBoxByIdAsync(Guid id) =>
            await this.donationBoxProcessingService.RemoveDonationBoxByIdAsync(id);
    }
}
