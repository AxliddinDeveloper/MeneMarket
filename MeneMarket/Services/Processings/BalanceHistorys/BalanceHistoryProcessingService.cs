using MeneMarket.Models.Foundations.BalanceHistorys;
using MeneMarket.Services.Foundations.BalanceHistorys;

namespace MeneMarket.Services.Processings.BalanceHistorys
{
    public class BalanceHistoryProcessingService : IBalanceHistoryProcessingService
    {
        private readonly IBalanceHistoryService balanceHistoryService;

        public BalanceHistoryProcessingService(
            IBalanceHistoryService balanceHistoryService) =>
                this.balanceHistoryService = balanceHistoryService;

        public async ValueTask<BalanceHistory> AddBalanceHistoryAsync(BalanceHistory balanceHistory) =>
            await this.balanceHistoryService.AddBalanceHistoryAsync(balanceHistory);

        public async ValueTask<BalanceHistory> ModifyBalanceHistoryAsync(BalanceHistory balanceHistory) =>
            await this.balanceHistoryService.ModifyBalanceHistoryAsync(balanceHistory);

        public async ValueTask<BalanceHistory> RemoveBalanceHistoryByIdAsync(Guid id) =>
            await this.balanceHistoryService.RemoveBalanceHistoryAsync(id);

        public IQueryable<BalanceHistory> RetrieveAllBalanceHistorys() =>
            this.balanceHistoryService.RetrieveAllBalanceHistorys();

        public async ValueTask<BalanceHistory> RetrieveBalanceHistoryByIdAsync(Guid id) =>
            await this.balanceHistoryService.RetrieveBalanceHistoryByIdAsync(id);
    }
}