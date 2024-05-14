using MeneMarket.Models.Foundations.Reports;
using Microsoft.EntityFrameworkCore;

namespace MeneMarket.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Report> Reports { get; set; }
        public async ValueTask<Report> InsertReportAsync(Report report) =>
            await InsertAsync(report);

        public IQueryable<Report> SelecctAllReports() =>
            SelectAll<Report>();

        public async ValueTask<Report> SelectReportByIdAsync(Guid id) =>
            await SelectAsync<Report>(id);

        public async ValueTask<Report> UpdateReportAsync(Report report) =>
            await UpdateAsync(report);

        public async ValueTask<Report> DeleteReportAsync(Report report) =>
            await DeleteAsync(report);
    }
}
