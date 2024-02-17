﻿using MeneMarket.Brokers.Storages;
using MeneMarket.Models.Foundations.DonationBoxes;

namespace MeneMarket.Services.Foundations.DonationBoxes
{
    public class DonationBoxService : IDonationBoxService
    {
        private readonly IStorageBroker storageBroker;

        public async ValueTask<DonationBox> AddDonationBoxAsync(DonationBox donationBox) =>
            await this.storageBroker.InsertDonationBoxAsync(donationBox);

        public async ValueTask<DonationBox> ModifyDonationBoxAsync(DonationBox donationBox) =>
            await this.storageBroker.UpdateDonationBoxAsync(donationBox);

        public async ValueTask<DonationBox> RemoveDonationBoxAsync(Guid id)
        {
            DonationBox donationBox = 
                await this.storageBroker.SelectDonationBoxByIdAsync(id);

            return await this.storageBroker.DeleteDonationBoxAsync(donationBox);
        }

        public async Task<List<DonationBox>> RetrieveAllDonationBoxesAsync() =>
            await this.storageBroker.SelectAllDonationBoxesAsync();

        public async ValueTask<DonationBox> RetrieveDonationBoxByIdAsync(Guid id) =>
            await this.storageBroker.SelectDonationBoxByIdAsync(id);
    }
}
