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

        public async ValueTask<Client> AddClientAsync(Client client)
        {
            client.ClientId = Guid.NewGuid();
            return await this.storageBroker.InsertClientAsync(client);
        }

        public async ValueTask<Client> ModifyClientAsync(Client client) =>
            await this.storageBroker.UpdateClientAsync(client);

        public async ValueTask<Client> RemoveClientAsync(Guid id)
        {
            Client selectedClient =
                await this.storageBroker.SelectClientByIdAsync(id);

            return await this.storageBroker.DeleteClientAsync(selectedClient);
        }

        public IQueryable<Client> RetrieveAllClients() =>
            this.storageBroker.SelectAllClients();

        public async ValueTask<Client> RetrieveClientByIdAsync(Guid id) =>
            await this.storageBroker.SelectClientByIdAsync(id);
    }
}
