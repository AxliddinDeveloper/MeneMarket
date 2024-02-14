﻿using MeneMarket.Models.Foundations.Products;
using MeneMarket.Services.Foundations.Products;

namespace MeneMarket.Services.Processings.Products
{
    public class ProductProcessingService : IProductProcessingService
    {
        private readonly IProductService productService;

        public ProductProcessingService(IProductService productService) =>
                this.productService = productService;

        public async ValueTask<Product> AddProductAsync(Product product) =>
            await this.productService.AddProductAsync(product);

        public async Task<List<Product>> RetrieveAllProductsAsync()
        {
            List<Product> allProducts =
                await this.productService.RetrieveAllProductsAsync();

            return allProducts;
        }

        public async ValueTask<Product> RetrieveProductByIdAsync(Guid id) =>
            await this.RetrieveProductByIdAsync(id);

        public async ValueTask<Product> ModifyProductAsync(Product product) =>
            await this.productService.ModifyProductAsync(product);

        public async ValueTask<Product> RemoveProductByIdAsync(Guid id)
        {
            Product selectProduct =
                await this.RetrieveProductByIdAsync(id);

            return await this.productService.RemoveProductAsync(selectProduct);
        }
    }
}