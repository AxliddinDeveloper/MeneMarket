using MeneMarket.Brokers.Storages;
using MeneMarket.Models.Foundations.Clients;

namespace MeneMarket.Services.Foundations.Clients
{
    public class ClientService : IClientService
    {
        private readonly IStorageBroker storageBroker;

        public ClientService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<Client> AddClientAsync(Client client) =>
            await this.storageBroker.InsertClientAsync(client);

        public async ValueTask<Client> ModifyClientAsync(Client client) =>
            await this.storageBroker.UpdateClientAsync(client);

        public async ValueTask<Client> RemoveClientAsync(Client client) =>
            await this.storageBroker.DeleteClientAsync(client);

        public IQueryable<Client> RetrieveAllClients() =>
            this.RetrieveAllClients();

        public async ValueTask<Client> RetrieveClientByIdAsync(Guid id) =>
            await this.storageBroker.SelectClientByIdAsync(id);
    }
}
