using MeneMarket.Models.Foundations.ProductRequests;
using Microsoft.EntityFrameworkCore;

namespace MeneMarket.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<ProductRequest> ProductRequests { get; set; }
    }
}
