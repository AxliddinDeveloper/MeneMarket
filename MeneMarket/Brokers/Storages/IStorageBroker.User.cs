using MeneMarket.Models.Foundations.Users;

namespace MeneMarket.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<User> InsertUserAsync(User user);
        IQueryable<User> SelectAllUsers();
    }
}