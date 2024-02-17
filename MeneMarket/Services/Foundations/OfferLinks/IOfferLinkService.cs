using MeneMarket.Models.Foundations.OfferLinks;

namespace MeneMarket.Services.Foundations.OfferLinks
{
    public interface IOfferLinkService
    {
        ValueTask<OfferLink> AddOfferLinkAsync(OfferLink offerLink);
        Task<List<OfferLink>> RetrieveAllOfferLinksAsync();
        ValueTask<OfferLink> RetrieveOfferLinkByIdAsync(Guid id);
        ValueTask<OfferLink> ModifyOfferLinkAsync(OfferLink offerLink);
        ValueTask<OfferLink> RemoveOfferLinkAsync(OfferLink offerLink);
    }
}