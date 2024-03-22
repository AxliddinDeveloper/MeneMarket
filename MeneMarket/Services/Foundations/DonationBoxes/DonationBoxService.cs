using MeneMarket.Brokers.Storages;
using MeneMarket.Models.Foundations.DonationBoxes;

namespace MeneMarket.Services.Foundations.DonationBoxes
{
    public class DonationBoxService : IDonationBoxService
    {
        private readonly IStorageBroker storageBroker;

        public DonationBoxService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<DonationBox> AddDonationBoxAsync(DonationBox donationBox)
        {
            donationBox.DonationBoxId = Guid.NewGuid();
            return await this.storageBroker.InsertDonationBoxAsync(donationBox);
        }

        public IQueryable<DonationBox> RetrieveAllDonationBoxes() =>
            this.storageBroker.SelectAllDonationBoxes();

        public async ValueTask<DonationBox> RetrieveDonationBoxByIdAsync(Guid id) =>
            await this.storageBroker.SelectDonationBoxByIdAsync(id);

        public async ValueTask<DonationBox> ModifyDonationBoxAsync(DonationBox donationBox) =>
            await this.storageBroker.UpdateDonationBoxAsync(donationBox);

        public async ValueTask<DonationBox> RemoveDonationBoxAsync(Guid id)
        {
            DonationBox donationBox =
                await this.storageBroker.SelectDonationBoxByIdAsync(id);

            return await this.storageBroker.DeleteDonationBoxAsync(donationBox);
        }
    }
}