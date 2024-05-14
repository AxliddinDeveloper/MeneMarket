using MeneMarket.Models.Foundations.Products;

namespace MeneMarket.Models.Orchestrations.CombinedProducts
{
    public class CombinedProducts
    {
        public IQueryable<Product> AllProducts { get; set; }
        public IQueryable<Product> PopularProducts { get; set; }
        public IQueryable<Product> NewProducts { get; set; }
    }
}