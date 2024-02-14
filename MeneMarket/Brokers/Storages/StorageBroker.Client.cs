using MeneMarket.Models.Foundations.Clients;
using Microsoft.EntityFrameworkCore;

namespace MeneMarket.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Client> Clients { get; set; }
    }
}
