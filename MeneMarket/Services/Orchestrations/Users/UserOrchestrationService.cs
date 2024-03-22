using EFxceptions.Models.Exceptions;
using MeneMarket.Models.Foundations.BalanceHistorys;
using MeneMarket.Models.Foundations.Users;
using MeneMarket.Services.Processings.BalanceHistorys;
using MeneMarket.Services.Processings.Files;
using MeneMarket.Services.Processings.Users;

namespace MeneMarket.Services.Orchestrations.Users
{
    public class UserOrchestrationService : IUserOrchestrationService
    {
        private readonly IUserProcessingService userProcessingService;
        private readonly IBalanceHistoryProcessingService balanceHistoryProcessingService;
        private readonly IFileProcessingService fileProcessingService;

        public UserOrchestrationService(
            IUserProcessingService userProcessingService,
            IFileProcessingService fileProcessingService,
        IBalanceHistoryProcessingService balanceHistoryProcessingService)
        {
            this.userProcessingService = userProcessingService;
            this.balanceHistoryProcessingService = balanceHistoryProcessingService;
            this.fileProcessingService = fileProcessingService;
        }

        public IQueryable<User> RetrieveAllUsers() =>
            this.userProcessingService.RetrieveAllUsers();

        public async ValueTask<User> RetrieveUserByIdAsync(Guid id) =>
            await this.userProcessingService.RetrieveUserByIdAsync(id);

        public async ValueTask<User> ModifyUserAsync(User user, IFormFile userImage)
        {
            decimal amount;

            User retrievedUser =
                await this.userProcessingService.RetrieveUserByIdAsync(user.UserId);

            if (retrievedUser != null && string.IsNullOrEmpty(retrievedUser.Image) && userImage != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    userImage.CopyTo(memoryStream);
                    memoryStream.Position = 0;

                    string filePath = await this.fileProcessingService.UploadFileAsync(
                        memoryStream, userImage.FileName);

                    user.Image = filePath;
                }
            }

            if (retrievedUser == null)
            {
                throw new InvalidObjectNameException("user is invalid.");
            }
            else if (user.Balance > retrievedUser.Balance)
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
            else if (user.Balance == retrievedUser.Balance)
                return await this.userProcessingService.ModifyUserAsync(user);
            else throw new NullReferenceException();
        }

        public async ValueTask<User> RemoveUserByIdAsync(Guid id) =>
            await this.userProcessingService.RemoveUserByIdAsync(id);
    }
}