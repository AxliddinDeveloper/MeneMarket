using MeneMarket.Models.Foundations.OfferLinks;
using Microsoft.EntityFrameworkCore;

namespace MeneMarket.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<OfferLink> OfferLinks { get; set; }

        public async ValueTask<OfferLink> InsertOfferLinkAsync(OfferLink offerLink) =>
            await InsertAsync(offerLink);

        public async Task<List<OfferLink>> SelectAllOfferLinksAsync()
        {
            return await this.OfferLinks
                .Include(p => p.Clients)
                .ToListAsync();
        }

        public async ValueTask<OfferLink> SelectOfferLinkByIdAsync(Guid id)
        {
            return await this.OfferLinks
               .Include(u => u.Clients)
              .FirstOrDefaultAsync(u => u.OfferLinkId == id);
        }

        public async ValueTask<OfferLink> UpdateOfferLinkAsync(OfferLink offerLink) =>
            await UpdateAsync(offerLink);

        public async ValueTask<OfferLink> DeleteOfferLinkAsync(OfferLink offerLink) =>
            await DeleteAsync(offerLink);
    }
}
