using MeneMarket.Models.Foundations.Users;
using Microsoft.EntityFrameworkCore;

namespace MeneMarket.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<User> Users { get; set; }
    }
}