using MeneMarket.Brokers.Storages;

namespace MeneMarket.Services.Foundations.Reports
{
    public class ReportService  
    {
        private readonly IStorageBroker storageBroker;

        public ReportService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }
    }
}
