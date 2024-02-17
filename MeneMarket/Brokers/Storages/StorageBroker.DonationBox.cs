using MeneMarket.Models.Foundations.DonationBoxes;
using Microsoft.EntityFrameworkCore;

namespace MeneMarket.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<DonationBox> Donations { get; set; }

        public async ValueTask<DonationBox> InsertDonationBoxAsync(DonationBox donationBox) =>
            await InsertAsync(donationBox);

        public async Task<List<DonationBox>> SelectAllDonationBoxesAsync()
        {
            return await this.Donations
                .Include(p => p.DonatedUsers)
                .ToListAsync();
        }

        public async ValueTask<DonationBox> SelectDonationBoxByIdAsync(Guid id) =>
            await SelectAsync<DonationBox>(id);

        public async ValueTask<DonationBox> UpdateDonationBoxAsync(DonationBox donationBox) =>
            await UpdateAsync(donationBox);

        public async ValueTask<DonationBox> DeleteDonationBoxAsync(DonationBox donationBox) =>
            await DeleteAsync(donationBox);
    }
}