using MeneMarket.Models.Foundations.OfferLinks;
using MeneMarket.Models.Foundations.Users;
using Microsoft.EntityFrameworkCore;

namespace MeneMarket.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<OfferLink> OfferLinks { get; set; }

        public async ValueTask<OfferLink> InsertOfferLinkAsync(OfferLink offerLink) =>
            await InsertAsync(offerLink);

        public IQueryable<OfferLink> SelectAllOfferLinks() =>
            SelectAll<OfferLink>();

        public async ValueTask<OfferLink> SelectOfferLinkByIdAsync(Guid offerLinkId) =>
            await SelectAsync<OfferLink>(offerLinkId);

        public async ValueTask<OfferLink> UpdateOfferLinkAsync(OfferLink offerLink) =>
            await UpdateAsync(offerLink);

        public async ValueTask<OfferLink> DeleteOfferLinkAsync(OfferLink offerLink) =>
            await DeleteAsync(offerLink);
    }
}
