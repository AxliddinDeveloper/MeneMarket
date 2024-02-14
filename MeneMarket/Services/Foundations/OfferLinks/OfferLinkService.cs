using MeneMarket.Brokers.Storages;
using MeneMarket.Models.Foundations.OfferLinks;

namespace MeneMarket.Services.Foundations.OfferLinks
{
    public class OfferLinkService : IOfferLinkService
    {
        private readonly IStorageBroker storageBroker;

        public OfferLinkService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<OfferLink> AddOfferLinkAsync(OfferLink offerLink) =>
            await this.storageBroker.InsertOfferLinkAsync(offerLink);

        public IQueryable<OfferLink> RetrieveAllOfferLinks() =>
            this.storageBroker.SelectAllOfferLinks();

        public async ValueTask<OfferLink> RetrieveOfferLinkByIdAsync(Guid id) =>
            await this.storageBroker.SelectOfferLinkByIdAsync(id);

        public async ValueTask<OfferLink> ModifyOfferLinkAsync(OfferLink offerLink) =>
            await this.storageBroker.UpdateOfferLinkAsync(offerLink);

        public async ValueTask<OfferLink> RemoveOfferLinkAsync(OfferLink offerLink) =>
            await this.storageBroker.DeleteOfferLinkAsync(offerLink);
    }
}
