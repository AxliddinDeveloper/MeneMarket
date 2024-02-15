using MeneMarket.Models.Foundations.Users;
using MeneMarket.Models.Orchestrations.LoginUsers;
using MeneMarket.Models.Orchestrations.Tokens;

namespace MeneMarket.Services.Orchestrations.Users
{
    public interface IUserSecurityOrchestrationService
    {
        ValueTask<User> AddUserAsync(User user);
        public UserToken LoginUser(LoginUser loginUser);

    }
}