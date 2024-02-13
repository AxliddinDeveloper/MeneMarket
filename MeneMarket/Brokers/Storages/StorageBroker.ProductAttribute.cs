using MeneMarket.Models.Foundations.ProductAttributes;
using Microsoft.EntityFrameworkCore;

namespace MeneMarket.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<ProductAttribute> ProductAttributes { get; set; }

        public async ValueTask<ProductAttribute> InsertProductAttributeAsync(ProductAttribute user) =>
            await InsertAsync(user);

        public IQueryable<ProductAttribute> SelectAllProductAttributes() =>
            SelectAll<ProductAttribute>();

        public async ValueTask<ProductAttribute> SelectProductAttributeByIdAsync(Guid userId) =>
            await SelectAsync<ProductAttribute>(userId);

        public async ValueTask<ProductAttribute> UpdateProductAttributeAsync(ProductAttribute user) =>
            await UpdateAsync(user);

        public async ValueTask<ProductAttribute> DeleteProductAttributeAsync(ProductAttribute user) =>
            await DeleteAsync(user);
    }
}