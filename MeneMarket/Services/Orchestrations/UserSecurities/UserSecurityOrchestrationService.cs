using MeneMarket.Models.Foundations.Users;
using MeneMarket.Models.Orchestrations.LoginUsers;
using MeneMarket.Models.Orchestrations.Tokens;
using MeneMarket.Services.Foundations.Tokens;
using MeneMarket.Services.Processings.Users;

namespace MeneMarket.Services.Orchestrations.Users
{
    public class UserSecurityOrchestrationService : IUserSecurityOrchestrationService
    {
        private readonly IUserProcessingService userProcessingService;
        private readonly ITokenService tokenService;

        public UserSecurityOrchestrationService(
            IUserProcessingService userProcessingService,
            ITokenService tokenService)
        {
            this.userProcessingService = userProcessingService;
            this.tokenService = tokenService;
        }

        public async ValueTask<User> AddUserAsync(User user)
        {
            user.UserId = Guid.NewGuid();
            return await this.userProcessingService.AddUserAsync(user);
        }

        public UserToken LoginUser(LoginUser loginUser)
        {
            IQueryable<User> allUsers = this.userProcessingService.RetrieveAllUsers();

            var result = allUsers.FirstOrDefault(retrievedUser =>
            retrievedUser.Email.Equals(loginUser.Email)
                    && retrievedUser.Password.Equals(loginUser.Password));

            if (result == null)
            {
                throw new Exception("Foydalanuvchi Topilmadi");
            }

            return this.tokenService.AddToken(result);
        }
    }
}