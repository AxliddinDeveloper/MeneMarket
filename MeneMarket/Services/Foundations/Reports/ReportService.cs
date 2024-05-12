using MeneMarket.Brokers.Storages;

namespace MeneMarket.Services.Foundations.Reports
{
    public class ReportService : IReportService
    {
        private readonly IStorageBroker storageBroker;

        public ReportService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }
    }
}
