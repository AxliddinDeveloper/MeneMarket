using MeneMarket.Models.Foundations.DonationBoxes;

namespace MeneMarket.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<DonationBox> InsertDonationBoxAsync(DonationBox donationBox);
        IQueryable<DonationBox> SelectAllDonationBoxes();
        ValueTask<DonationBox> SelectDonationBoxByIdAsync(Guid id);
        ValueTask<DonationBox> UpdateDonationBoxAsync(DonationBox donationBox);
        ValueTask<DonationBox> DeleteDonationBoxAsync(DonationBox donationBox);
    }
}