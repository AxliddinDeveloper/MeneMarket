using MeneMarket.Models.Foundations.DonationBoxes;

namespace MeneMarket.Services.Processings.DonationBoxes
{
    public interface IDonationBoxProcessingService
    {
        ValueTask<DonationBox> AddUserAsync(DonationBox donationBox);
        IQueryable<DonationBox> RetrieveAllUsers();
        ValueTask<DonationBox> RetrieveUserByIdAsync(Guid id);
        ValueTask<DonationBox> ModifyUserAsync(DonationBox donationBox);
        ValueTask<DonationBox> RemoveUserByIdAsync(Guid id);
    }
}