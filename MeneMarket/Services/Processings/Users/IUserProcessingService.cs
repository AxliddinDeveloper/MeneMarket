using MeneMarket.Models.Foundations.Users;

namespace MeneMarket.Services.Processings.Users
{
    public interface IUserProcessingService
    {
        ValueTask<User> AddUserAsync(User user);
        IQueryable<User> RetrieveAllUsers();
        ValueTask<User> RetrieveUserByIdAsync(Guid id);
        ValueTask<User> ModifyUserAsync(User user);
        ValueTask<User> RemoveUserByIdAsync(Guid id);
    }
}
