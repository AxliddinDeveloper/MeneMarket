using MeneMarket.Models.Foundations.Clients;
using MeneMarket.Services.Foundations.Clients;
using MeneMarket.Services.Foundations.OfferLinks;

namespace MeneMarket.Services.Orchestrations.Clients
{
    public class ClientOrchestrationService : IClientOrchestrationService
    {
        private readonly IClientService clientService;
        private readonly IOfferLinkService offerLinkService;

        public ClientOrchestrationService(
            IClientService clientService, 
            IOfferLinkService offerLinkService)
        {
            this.clientService = clientService;
            this.offerLinkService = offerLinkService;
        }

        public async ValueTask<string> AddClientAsync(Guid id, string ipAddress)
        {
            var client = new Client
            {
                ClientId = Guid.NewGuid(),
                IpAddress = ipAddress,
                StatusType = StatusType.Visit,
                OfferLinkId = id
            };

            await clientService.AddClientAsync(client);

            var selectedOfferLink = 
                await this.offerLinkService.RetrieveOfferLinkByIdAsync(id);

            return selectedOfferLink.Link;
        }

        public IQueryable<Client> RetrieveAllClients() =>
            this.clientService.RetrieveAllClients();

        public async ValueTask<Client> RetrieveClientByIdAsync(Guid id) =>
            await this.clientService.RetrieveClientByIdAsync(id);

        public async ValueTask<Client> ModifyClientAsync(Client client) =>
            await this.clientService.ModifyClientAsync(client);

        public async ValueTask<Client> RemoveClientByIdAsync(Guid id) =>
            await this.clientService.RemoveClientAsync(id);
    }
}