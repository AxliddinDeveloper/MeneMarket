using MeneMarket.Models.Foundations.DonationBoxes;

namespace MeneMarket.Services.Foundations.DonationBoxes
{
    public interface IDonationBoxService
    {
        ValueTask<DonationBox> AddDonationBoxAsync(DonationBox donationBox);
        IQueryable<DonationBox> RetrieveAllDonationBoxes();
        ValueTask<DonationBox> RetrieveDonationBoxByIdAsync(Guid id);
        ValueTask<DonationBox> ModifyDonationBoxAsync(DonationBox donationBox);
        ValueTask<DonationBox> RemoveDonationBoxAsync(Guid id);
    }
}