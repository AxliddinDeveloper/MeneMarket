using MeneMarket.Models.Foundations.BalanceHistorys;

namespace MeneMarket.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<BalanceHistory> InsertBalanceHistoryAsync(BalanceHistory balanceHistory);
        IQueryable<BalanceHistory> SelectAllBalanceHistorys();
        ValueTask<BalanceHistory> SelectBalanceHistoryByIdAsync(Guid id);
        ValueTask<BalanceHistory> UpdateBalanceHistoryAsync(BalanceHistory balanceHistory);
        ValueTask<BalanceHistory> DeleteBalanceHistoryAsync(BalanceHistory balanceHistory);
    }
}