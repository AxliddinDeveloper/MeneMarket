using MeneMarket.Models.Foundations.Clients;

namespace MeneMarket.Services.Orchestrations.Clients
{
    public interface IClientOrchestrationService
    {
        ValueTask<string> AddClientAsync(Guid id, string ipAddress);
        IQueryable<Client> RetrieveAllClients();
        ValueTask<Client> RetrieveClientByIdAsync(Guid id);
        ValueTask<Client> ModifyClientAsync(Client client);
        ValueTask<Client> RemoveClientByIdAsync(Guid id);
    }
}