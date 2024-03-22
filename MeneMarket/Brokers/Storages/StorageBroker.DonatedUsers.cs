using MeneMarket.Models.Foundations.DonatedUsers;
using Microsoft.EntityFrameworkCore;

namespace MeneMarket.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<DonatedUser> DonatedUsers { get; set; }

        public async ValueTask<DonatedUser> InsertDonatedUserAsync(DonatedUser donatedUser) =>
            await InsertAsync(donatedUser);

        public IQueryable<DonatedUser> SelectAllDonatedUsers() =>
            SelectAll<DonatedUser>();

        public async ValueTask<DonatedUser> SelectDonatedUserByIdAsync(Guid id) =>
            await SelectAsync<DonatedUser>(id);

        public async ValueTask<DonatedUser> UpdateDonatedUserAsync(DonatedUser donatedUser) =>
            await UpdateAsync(donatedUser);

        public async ValueTask<DonatedUser> DeleteDonatedUserAsync(DonatedUser donatedUser) =>
            await DeleteAsync(donatedUser);
    }
}
