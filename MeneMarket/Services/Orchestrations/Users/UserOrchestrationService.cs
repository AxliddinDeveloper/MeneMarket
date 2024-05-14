using System.Security.Claims;
using EFxceptions.Models.Exceptions;
using MeneMarket.Models.Foundations.BalanceHistorys;
using MeneMarket.Models.Foundations.Users;
using MeneMarket.Models.Orchestrations.UserWithImages;
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

        public async ValueTask<User> RetrieveUserProfileAsync(ClaimsPrincipal user)
        {
            var userIdClaim = user.Claims.FirstOrDefault(c => c.Type == "UserId");
            Guid.TryParse(userIdClaim.Value, out Guid userId);

            return await this.userProcessingService.RetrieveUserByIdAsync(userId);
        }

        public async ValueTask<User> ModifyUserAsync(UserWithImages userWithImages)
        {
            decimal amount;

            User retrievedUser =
                await this.userProcessingService.RetrieveUserByIdAsync(userWithImages.User.UserId);

            if (retrievedUser != null && userWithImages.bytes != null && userWithImages.bytes != "string")
            {
                string fileName = Guid.NewGuid().ToString() + ".webp";
                byte[] bytes = Convert.FromBase64String(userWithImages.bytes);
                var memoryStream = ConvertBytesToMemoryStream(bytes);

                string filePath = await this.fileProcessingService.UploadFileAsync(
                    memoryStream, fileName, 600, 600);

                userWithImages.User.Image = filePath;
            }

            if (retrievedUser == null)
            {
                throw new InvalidObjectNameException("user is invalid.");
            }
            else if (userWithImages.User.Balance > retrievedUser.Balance)
            {
                amount = userWithImages.User.Balance - retrievedUser.Balance;

                var balanceHistory = new BalanceHistory
                {
                    Id = Guid.NewGuid(),
                    Amount = $"+ {amount}",
                    TransactionDate = DateTime.UtcNow,
                    UserId = userWithImages.User.UserId,
                };

                await this.balanceHistoryProcessingService.AddBalanceHistoryAsync(balanceHistory);

                return await this.userProcessingService.ModifyUserAsync(userWithImages.User);
            }
            else if (userWithImages.User.Balance < retrievedUser.Balance)
            {
                amount = userWithImages.User.Balance - retrievedUser.Balance;

                var balanceHistory = new BalanceHistory
                {
                    Id = Guid.NewGuid(),
                    Amount = amount.ToString(),
                    TransactionDate = DateTime.UtcNow,
                    UserId = userWithImages.User.UserId,
                };

                await this.balanceHistoryProcessingService.AddBalanceHistoryAsync(balanceHistory);

                return await this.userProcessingService.ModifyUserAsync(userWithImages.User);
            }
            else if (userWithImages.User.Balance == retrievedUser.Balance)
                return await this.userProcessingService.ModifyUserAsync(userWithImages.User);
            else throw new NullReferenceException();
        }

        public async ValueTask<User> RemoveUserByIdAsync(Guid id) =>
            await this.userProcessingService.RemoveUserByIdAsync(id);

        public MemoryStream ConvertBytesToMemoryStream(byte[] bytes)
        {
            MemoryStream memoryStream = new MemoryStream(bytes);
            return memoryStream;
        }
    }
}