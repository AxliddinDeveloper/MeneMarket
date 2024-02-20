using EFxceptions.Models.Exceptions;
using MeneMarket.Models.Foundations.BalanceHistorys;
using MeneMarket.Models.Foundations.Users;
using MeneMarket.Services.Processings.BalanceHistorys;
using MeneMarket.Services.Processings.Users;

namespace MeneMarket.Services.Orchestrations.Users
{
    public class UserOrchestrationService : IUserOrchestrationService
    {
        private readonly IUserProcessingService userProcessingService;
        private readonly IBalanceHistoryProcessingService balanceHistoryProcessingService;

        public UserOrchestrationService(
            IUserProcessingService userProcessingService, 
            IBalanceHistoryProcessingService balanceHistoryProcessingService)
        {
            this.userProcessingService = userProcessingService;
            this.balanceHistoryProcessingService = balanceHistoryProcessingService;
        }

        public IQueryable<User> RetrieveAllUsers() =>
            this.userProcessingService.RetrieveAllUsers();

        public async ValueTask<User> RetrieveUserByIdAsync(Guid id) =>
            await this.userProcessingService.RetrieveUserByIdAsync(id);

        public async ValueTask<User> ModifyUserAsync(User user)
        {
            decimal amount;

            User retrievedUser = 
                await this.userProcessingService.RetrieveUserByIdAsync(user.UserId);

            if (retrievedUser == null)
            {
                throw new InvalidObjectNameException("user is invalid.");
            }
            else if(user.Balance >  retrievedUser.Balance)
            {
                amount = user.Balance - retrievedUser.Balance;

                var balanceHistory = new BalanceHistory
                {
                    Id = Guid.NewGuid(),
                    Amount = $"+ {amount}",
                    TransactionDate = DateTime.UtcNow,
                    UserId = user.UserId,
                };

                await this.balanceHistoryProcessingService.AddBalanceHistoryAsync(balanceHistory);

                return await this.userProcessingService.ModifyUserAsync(user);
            }
            else if (user.Balance < retrievedUser.Balance)
            {
                amount = user.Balance - retrievedUser.Balance;

                var balanceHistory = new BalanceHistory
                {
                    Id = Guid.NewGuid(),
                    Amount = amount.ToString(),
                    TransactionDate = DateTime.UtcNow,
                    UserId = user.UserId,
                };

                await this.balanceHistoryProcessingService.AddBalanceHistoryAsync(balanceHistory);

                return await this.userProcessingService.ModifyUserAsync(user);
            }
            else throw new NullReferenceException();
        }

        public async ValueTask<User> RemoveUserByIdAsync(Guid id) =>
            await this.userProcessingService.RemoveUserByIdAsync(id);
    }
}