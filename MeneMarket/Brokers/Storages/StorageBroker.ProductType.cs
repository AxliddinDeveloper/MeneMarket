using MeneMarket.Models.Foundations.ProductTypes;
using Microsoft.EntityFrameworkCore;

namespace MeneMarket.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<ProductType> ProductTypes { get; set; }

        public async ValueTask<ProductType> InsertProductTypeAsync(ProductType ProductType) =>
            await InsertAsync(ProductType);

        public IQueryable<ProductType> SelectAllProductTypes() =>
            SelectAll<ProductType>();

        public async ValueTask<ProductType> SelectProductTypeByIdAsync(Guid id) =>
            await SelectAsync<ProductType>(id);

        public async ValueTask<ProductType> UpdateProductTypeAsync(ProductType ProductType) =>
            await UpdateAsync(ProductType);

        public async ValueTask<ProductType> DeleteProductTypeAsync(ProductType ProductType) =>
            await DeleteAsync(ProductType);
    }
}