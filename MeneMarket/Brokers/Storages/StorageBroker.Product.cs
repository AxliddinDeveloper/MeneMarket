using MeneMarket.Models.Foundations.Products;
using Microsoft.EntityFrameworkCore;

namespace MeneMarket.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Product> Products { get; set; }

        public async ValueTask<Product> InsertProductAsync(Product product) =>
            await InsertAsync(product);

        public async Task<List<Product>> SelectAllProductsAsync()
        {
            return await this.Products.Include(p => 
                p.ProductAttributes)
                    .ToListAsync();
        }

        public async ValueTask<Product> SelectProductByIdAsync(Guid productId) =>
             await this.Products.Include(u => u.ProductAttributes)
                    .FirstOrDefaultAsync(u => u.ProductId == productId);

        public async ValueTask<Product> UpdateProductAsync(Product product) =>
            await UpdateAsync(product);

        public async ValueTask<Product> DeleteProductAsync(Product product) =>
            await DeleteAsync(product);
    }
}