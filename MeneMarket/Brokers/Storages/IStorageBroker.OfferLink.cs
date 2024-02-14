using MeneMarket.Models.Foundations.OfferLinks;
using MeneMarket.Models.Foundations.Users;

namespace MeneMarket.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<OfferLink> InsertOfferLinkAsync(OfferLink offerLink);
        IQueryable<OfferLink> SelectAllOfferLinks();
        ValueTask<OfferLink> SelectOfferLinkByIdAsync(Guid offerLinkId);
        ValueTask<OfferLink> UpdateOfferLinkAsync(OfferLink offerLink);
        ValueTask<OfferLink> DeleteOfferLinkAsync(OfferLink offerLink);
    }
}
