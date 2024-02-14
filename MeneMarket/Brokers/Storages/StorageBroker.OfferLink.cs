using MeneMarket.Models.Foundations.OfferLinks;
using Microsoft.EntityFrameworkCore;

namespace MeneMarket.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<OfferLink> OfferLinks { get; set; }
    }
}
