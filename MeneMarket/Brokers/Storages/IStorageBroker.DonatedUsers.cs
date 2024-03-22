using MeneMarket.Models.Foundations.DonatedUsers;

namespace MeneMarket.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<DonatedUser> InsertDonatedUserAsync(DonatedUser donatedUser);
        IQueryable<DonatedUser> SelectAllDonatedUsers();
        ValueTask<DonatedUser> SelectDonatedUserByIdAsync(Guid id);
        ValueTask<DonatedUser> UpdateDonatedUserAsync(DonatedUser donatedUser);
        ValueTask<DonatedUser> DeleteDonatedUserAsync(DonatedUser donatedUser);
    }
}