using MeneMarket.Brokers.Storages;
using MeneMarket.Models.Foundations.Users;

namespace MeneMarket.Services.Foundations.Users
{
    public class UserService : IUserService
    {
        private readonly IStorageBroker storageBroker;

        public UserService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<User> AddUserAsync(User user) =>
            await this.storageBroker.InsertUserAsync(user);

        public IQueryable<User> RetrieveAllUsers() =>
            this.storageBroker.SelectAllUsers();

        public async ValueTask<User> RetrieveUserByIdAsync(Guid id) =>
            await this.storageBroker.SelectUserByIdAsync(id);

        public async ValueTask<User> ModifyUserAsync(User user) =>
            await this.storageBroker.UpdateUserAsync(user);

        public async ValueTask<User> RemoveUserAsync(Guid id)
        {
            User mayBeUser =
                await this.storageBroker.SelectUserByIdAsync(id);

            return await this.storageBroker.DeleteUserAsync(mayBeUser);
        }
    }
}
