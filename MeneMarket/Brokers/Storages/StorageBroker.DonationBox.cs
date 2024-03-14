using MeneMarket.Models.Foundations.DonationBoxes;
using Microsoft.EntityFrameworkCore;

namespace MeneMarket.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<DonationBox> Donations { get; set; }

        public async ValueTask<DonationBox> InsertDonationBoxAsync(DonationBox donationBox) =>
            await InsertAsync(donationBox);

        public IQueryable<DonationBox> SelectAllDonationBoxes() =>
            this.SelectAll<DonationBox>();

        public async ValueTask<DonationBox> SelectDonationBoxByIdAsync(Guid id) =>
             await this.Donations.FirstOrDefaultAsync(d => d.DonationBoxId == id);

        public async ValueTask<DonationBox> UpdateDonationBoxAsync(DonationBox donationBox) =>
            await UpdateAsync(donationBox);

        public async ValueTask<DonationBox> DeleteDonationBoxAsync(DonationBox donationBox) =>
            await DeleteAsync(donationBox);
    }
}