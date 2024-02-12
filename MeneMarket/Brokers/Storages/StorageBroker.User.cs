using MeneMarket.Models.Foundations.Users;
using Microsoft.EntityFrameworkCore;

namespace MeneMarket.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<User> Users { get; set; }

        public async ValueTask<User> InsertUserAsync(User user) =>
            await InsertAsync(user);

        public IQueryable<User> SelectAllUsers() =>
            SelectAll<User>();
        public async ValueTask<User> SelectUserByIdAsync(Guid userId) =>
            await SelectAsync<User>(userId);
    }
}