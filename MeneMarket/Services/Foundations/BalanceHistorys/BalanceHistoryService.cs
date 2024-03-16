using MeneMarket.Brokers.Storages;
using MeneMarket.Models.Foundations.BalanceHistorys;

namespace MeneMarket.Services.Foundations.BalanceHistorys
{
    public class BalanceHistoryService : IBalanceHistoryService
    {
        private readonly IStorageBroker storageBroker;

        public BalanceHistoryService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<BalanceHistory> AddBalanceHistoryAsync(BalanceHistory balanceHistory) =>
            await this.storageBroker.InsertBalanceHistoryAsync(balanceHistory);

        public IQueryable<BalanceHistory> RetrieveAllBalanceHistorys() =>
             this.storageBroker.SelectAllBalanceHistorys();

        public async ValueTask<BalanceHistory> RetrieveBalanceHistoryByIdAsync(Guid id) =>
            await this.storageBroker.SelectBalanceHistoryByIdAsync(id);

        public async ValueTask<BalanceHistory> ModifyBalanceHistoryAsync(BalanceHistory balanceHistory) =>
            await this.storageBroker.UpdateBalanceHistoryAsync(balanceHistory);

        public async ValueTask<BalanceHistory> RemoveBalanceHistoryAsync(Guid id)
        {
            BalanceHistory selectedBalanceHistory =
                await this.storageBroker.SelectBalanceHistoryByIdAsync(id);

            return await this.storageBroker.DeleteBalanceHistoryAsync(selectedBalanceHistory);
        }
    }
}
