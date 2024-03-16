using MeneMarket.Brokers.Storages;
using MeneMarket.Models.Foundations.Products;

namespace MeneMarket.Services.Foundations.Products
{
    public class ProductService : IProductService
    {
        private readonly IStorageBroker storageBroker;

        public ProductService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<Product> AddProductAsync(Product product)
        {
            return await this.storageBroker.InsertProductAsync(product);
        }

        public IQueryable<Product> RetrieveAllProducts() =>
            this.storageBroker.SelectAllProducts();

        public async ValueTask<Product> RetrieveProductByIdAsync(Guid id) =>
            await this.storageBroker.SelectProductByIdAsync(id);

        public async ValueTask<Product> ModifyProductAsync(Product product) =>
            await this.storageBroker.UpdateProductAsync(product);

        public async ValueTask<Product> RemoveProductAsync(Guid id)
        {
            Product mayBeProduct =
                await this.storageBroker.SelectProductByIdAsync(id);

            return await this.storageBroker.DeleteProductAsync(mayBeProduct);
        }
    }
}