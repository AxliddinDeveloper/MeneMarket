using MeneMarket.Models.Foundations.OfferLinks;
using MeneMarket.Models.Foundations.Users;

namespace MeneMarket.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<OfferLink> InsertOfferLinkAsync(OfferLink offerLink);
        Task<List<OfferLink>> SelectAllOfferLinksAsync();
        ValueTask<OfferLink> SelectOfferLinkByIdAsync(Guid id);
        ValueTask<OfferLink> UpdateOfferLinkAsync(OfferLink offerLink);
        ValueTask<OfferLink> DeleteOfferLinkAsync(OfferLink offerLink);
    }
}