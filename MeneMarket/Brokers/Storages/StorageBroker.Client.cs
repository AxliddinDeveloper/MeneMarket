using MeneMarket.Models.Foundations.Clients;
using Microsoft.EntityFrameworkCore;

namespace MeneMarket.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Client> Clients { get; set; }

        public async ValueTask<Client> InsertClientAsync(Client client) =>
            await InsertAsync(client);

        public IQueryable<Client> SelectAllClients() =>
            SelectAll<Client>();

        public async ValueTask<Client> SelectClientByIdAsync(Guid clientId) =>
            await SelectAsync<Client>(clientId);

        public async ValueTask<Client> UpdateClientAsync(Client client) =>
            await UpdateAsync(client);

        public async ValueTask<Client> DeleteClientAsync(Client client) =>
            await DeleteAsync(client);
    }
}