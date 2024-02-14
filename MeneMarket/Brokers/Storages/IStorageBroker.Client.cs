using MeneMarket.Models.Foundations.Clients;

namespace MeneMarket.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Client> InsertClientAsync(Client client);
        IQueryable<Client> SelectAllClients();
        ValueTask<Client> SelectClientByIdAsync(Guid clientId);
        ValueTask<Client> UpdateClientAsync(Client client);
        ValueTask<Client> DeleteClientAsync(Client client);
    }
}