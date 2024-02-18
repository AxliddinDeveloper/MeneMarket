using MeneMarket.Models.Foundations.BalanceHistorys;
using Microsoft.EntityFrameworkCore;

namespace MeneMarket.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<BalanceHistory> BalanceHistorys { get; set; }

        public async ValueTask<BalanceHistory> InsertBalanceHistoryAsync(BalanceHistory balanceHistory) =>
            await InsertAsync(balanceHistory);

        public IQueryable<BalanceHistory> SelectAllBalanceHistorys() =>
            SelectAll<BalanceHistory>();

        public async ValueTask<BalanceHistory> SelectBalanceHistoryByIdAsync(Guid id) =>
            await SelectAsync<BalanceHistory>(id);

        public async ValueTask<BalanceHistory> UpdateBalanceHistoryAsync(BalanceHistory balanceHistory) =>
            await UpdateAsync(balanceHistory);

        public async ValueTask<BalanceHistory> DeleteBalanceHistoryAsync(BalanceHistory balanceHistory) =>
            await DeleteAsync(balanceHistory);
    }
}