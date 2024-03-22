using MeneMarket.Models.Foundations.Users;

namespace MeneMarket.Services.Orchestrations.Users
{
    public interface IUserOrchestrationService
    {
        IQueryable<User> RetrieveAllUsers();
        ValueTask<User> RetrieveUserByIdAsync(Guid id);
        ValueTask<User> ModifyUserAsync(User user, IFormFile userImage);
        ValueTask<User> RemoveUserByIdAsync(Guid id);
    }
}