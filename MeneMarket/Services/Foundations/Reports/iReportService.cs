using MeneMarket.Models.Foundations.Reports;

namespace MeneMarket.Services.Foundations.Reports
{
    public interface IReportService
    {
        ValueTask<Report> AddReportAsync(Report report);
        IQueryable<Report> RetrieveAllReports();
        ValueTask<Report> SelectReportByIdAsync(Guid Id);
        ValueTask<Report> ModifyReportAsync(Report report);
        ValueTask<Report> DeleteReportAsync(Guid Id);
    }
}