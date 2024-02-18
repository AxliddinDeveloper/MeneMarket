using MeneMarket.Models.Foundations.BalanceHistorys;

namespace MeneMarket.Services.Foundations.BalanceHistorys
{
    public interface IBalanceHistoryService
    {
        ValueTask<BalanceHistory> AddBalanceHistoryAsync(BalanceHistory balanceHistory);
        IQueryable<BalanceHistory> RetrieveAllBalanceHistorys();
        ValueTask<BalanceHistory> RetrieveBalanceHistoryByIdAsync(Guid id);
        ValueTask<BalanceHistory> ModifyBalanceHistoryAsync(BalanceHistory balanceHistory);
        ValueTask<BalanceHistory> RemoveBalanceHistoryAsync(Guid id);
    }
}