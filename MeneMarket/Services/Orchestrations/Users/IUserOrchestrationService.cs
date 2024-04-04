using MeneMarket.Models.Foundations.Users;
using MeneMarket.Models.Orchestrations.UserWithImages;

namespace MeneMarket.Services.Orchestrations.Users
{
    public interface IUserOrchestrationService
    {
        IQueryable<User> RetrieveAllUsers();
        ValueTask<User> RetrieveUserByIdAsync(Guid id);
        ValueTask<User> ModifyUserAsync(UserWithImages userWithImages);
        ValueTask<User> RemoveUserByIdAsync(Guid id);
    }
}