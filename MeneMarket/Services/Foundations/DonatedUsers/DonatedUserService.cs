using MeneMarket.Brokers.Storages;
using MeneMarket.Models.Foundations.DonatedUsers;

namespace MeneMarket.Services.Foundations.DonatedUsers
{
    public class DonatedUserService : IDonatedUserService
    {
        private readonly IStorageBroker storageBroker;

        public DonatedUserService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<DonatedUser> AddDonatedUserAsync(DonatedUser donatedUser) =>
            await this.storageBroker.InsertDonatedUserAsync(donatedUser);

        public IQueryable<DonatedUser> RetrieveAllDonatedUsers() =>
            this.storageBroker.SelectAllDonatedUsers();

        public async ValueTask<DonatedUser> RetrieveDonatedUserByIdAsync(Guid id) =>
            await this.storageBroker.SelectDonatedUserByIdAsync(id);

        public async ValueTask<DonatedUser> ModifyDonatedUserAsync(DonatedUser donatedUser) =>
            await this.storageBroker.UpdateDonatedUserAsync(donatedUser);

        public async ValueTask<DonatedUser> RemoveDonatedUserAsync(Guid id)
        {
            DonatedUser donatedUser = await this.storageBroker.SelectDonatedUserByIdAsync(id);

            return await this.storageBroker.DeleteDonatedUserAsync(donatedUser);
        }
    }
}
