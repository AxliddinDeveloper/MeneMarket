using MeneMarket.Models.Foundations.DonationBoxes;

namespace MeneMarket.Services.Orchestrations.DonationBoxes
{
    public interface IDonationBoxOrchestrationService
    {
        ValueTask<DonationBox> AddDonationBoxAsync(DonationBox donationBox);
        IQueryable<DonationBox> RetrieveAllDonationBoxes();
        ValueTask<DonationBox> RetrieveDonationBoxByIdAsync(Guid id);
        ValueTask<DonationBox> ModifyDonationBoxAsync(DonationBox donationBox, Guid id, bool outBalance);
        ValueTask<DonationBox> RemoveDonationBoxByIdAsync(Guid id);
    }
}