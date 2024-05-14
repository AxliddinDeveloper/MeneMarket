using MeneMarket.Brokers.Storages;
using MeneMarket.Models.Foundations.Reports;

namespace MeneMarket.Services.Foundations.Reports
{
    public class ReportService : IReportService
    {
        private readonly IStorageBroker storageBroker;

        public ReportService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public async ValueTask<Report> AddReportAsync(Report report) =>
            await this.storageBroker.InsertReportAsync(report);

        public IQueryable<Report> RetrieveAllReports() =>
            this.RetrieveAllReports();

        public async ValueTask<Report> RemoveReportAsync(Guid id)
        {
            var report = await this.storageBroker.SelectReportByIdAsync(id);

            return await this.storageBroker.DeleteReportAsync(report);
        }
    }
}
