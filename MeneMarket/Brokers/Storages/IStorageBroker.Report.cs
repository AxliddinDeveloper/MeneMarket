using MeneMarket.Models.Foundations.Reports;

namespace MeneMarket.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Report> InsertReportAsync(Report report);
        IQueryable<Report> SelecctAllReports();
        ValueTask<Report> SelectReportByIdAsync(Guid id);
        ValueTask<Report> UpdateReportAsync(Report report);
        ValueTask<Report> DeleteReportAsync(Report report);
    }
}