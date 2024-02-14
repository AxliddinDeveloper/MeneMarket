using MeneMarket.Models.Foundations.Clients;

namespace MeneMarket.Services.Foundations.Clients
{
    public interface IClientService
    {
        ValueTask<Client> AddClientAsync(Client client);
        IQueryable<Client> RetrieveAllClients();
        ValueTask<Client> RetrieveClientByIdAsync(Guid id);
        ValueTask<Client> ModifyClientAsync(Client client);
        ValueTask<Client> RemoveClientAsync(Client client);
    }
}