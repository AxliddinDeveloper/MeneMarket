using MeneMarket.Models.Foundations.BalanceHistorys;

namespace MeneMarket.Services.Processings.BalanceHistorys
{
    public interface IBalanceHistoryProcessingService
    {
        ValueTask<BalanceHistory> AddBalanceHistoryAsync(BalanceHistory balanceHistory);
        IQueryable<BalanceHistory> RetrieveAllBalanceHistorys();
        ValueTask<BalanceHistory> RetrieveBalanceHistoryByIdAsync(Guid id);
        ValueTask<BalanceHistory> ModifyBalanceHistoryAsync(BalanceHistory balanceHistory);
        ValueTask<BalanceHistory> RemoveBalanceHistoryByIdAsync(Guid id);
    }
}