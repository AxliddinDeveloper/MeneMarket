using MeneMarket.Models.Foundations.DonatedUsers;

namespace MeneMarket.Services.Foundations.DonatedUsers
{
    public interface IDonatedUserService
    {
        ValueTask<DonatedUser> AddDonatedUserAsync(DonatedUser donatedUser);
        IQueryable<DonatedUser> RetrieveAllDonatedUsers();
        ValueTask<DonatedUser> RetrieveDonatedUserByIdAsync(Guid id);
        ValueTask<DonatedUser> ModifyDonatedUserAsync(DonatedUser donatedUser);
        ValueTask<DonatedUser> RemoveDonatedUserAsync(Guid id);
    }
}
